using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;



namespace ServerSide
{
    public delegate void SetTextCallBack(Point x);
    public delegate void Hello();
    public partial class Form1 : Form
    {
        private BackgroundWorker bw = new BackgroundWorker();
        public bool flag_btn_server;
        SettingsForm setForm = new SettingsForm();
        GraphicForm graphicForm = new GraphicForm();
        Pt pt = new Pt();
        Image image;
        ListForm listForm = new ListForm();
        readonly Server serverObject = new Server();
        InterpolationForm interForm = new InterpolationForm();
        List<MyPoint> globalMyPointList = new List<MyPoint>();
        EncryptionClass encrObj = new EncryptionClass();

        public Form1()
        {
            InitializeComponent();

            image = ServerSide.Properties.Resources.THE_MAP;
            pictureBox1.Size = image.Size;
            pictureBox1.Image = image; 
            Graphics e = pictureBox1.CreateGraphics();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = interForm.max+5;

            Resize += Form1_Resize;
            byte[] s = new byte[1024];

            serverObject.ListEvent += (ev) => listForm.listBox1.Invoke(new Action(() => listForm.listBox1.Items.Add(ev.Message)));
            listForm.FormClosing += (obivan, canobi) =>
                {
                    if (canobi.CloseReason == CloseReason.UserClosing)
                    {
                        canobi.Cancel = true;
                        listForm.listBox1.Items.Clear();
                        listForm.Hide();
                    }
                };
            listForm.listBox1.SelectedIndexChanged += (obj, even) =>
            {
                serverObject.ListMethode((string)listForm.listBox1.SelectedItem);
            };
            
            //Setting plot on main form
            setForm.SettingAction += a =>
            {
                if (InvokeRequired)
                    pictureBox1.Invoke(new Action(() => 
                    {
                        image = new Bitmap(a.Picture, pictureBox1.Size);
                        pictureBox1.Image = image;
                    }));
                else
                {
                    image = new Bitmap(a.Picture, pictureBox1.Size);
                    pictureBox1.Image = image;
                }
            };

            //Show messages from server
            serverObject.ServerEvent += a =>
            {
                if (label1.InvokeRequired)
                    label1.Invoke(new Action(() => { label1.Text += a.Message; }));
                else
                    label1.Text = a.Message;
            };

            //ProgressBar of interpolation progress
            interForm.InterAction += a =>
            {
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    if (progressBar1.InvokeRequired)
                        progressBar1.Invoke(new Action(() => { progressBar1.Value += a.Value; }));
                    else
                        progressBar1.Value = a.Value;
                }
            };

            //Draw recieved point from server and place this one into array
            serverObject.ServerEvent1 += a =>
            {
                globalMyPointList.Add(a.Mypt);
                if (globalMyPointList.Count > 1 && a.Mypt.Tracker == "1")
                {
                    LinearGradientBrush lGB = new LinearGradientBrush(globalMyPointList[globalMyPointList.Count - 1].Cords, globalMyPointList[globalMyPointList.Count - 2].Cords,
                                    Color.FromArgb(250, Color.DarkOrchid), Color.FromArgb(10, Color.DarkOrchid));
                    if (pictureBox1.InvokeRequired)
                    {
                        pictureBox1.Invoke(new Action(() =>
                            {
                                e.DrawLine(new Pen(lGB),
                                    globalMyPointList[globalMyPointList.Count - 2].Cords, globalMyPointList[globalMyPointList.Count - 1].Cords);
                            }));
                    }
                }
                else
                {
                    if (setForm.DrawingOffOn())
                    {
                        if (pictureBox1.InvokeRequired)
                        {
                            pictureBox1.Invoke(new Action(() =>
                            {
                                e.FillRectangle(new SolidBrush(Color.FromArgb(a.Mypt.Intensity * 51, Color.DarkOrchid)), new Rectangle(a.Mypt.Cords.X, a.Mypt.Cords.Y, 3, 3));
                            }));
                            setForm.SoundsOffOn();
                        }
                        else
                        {
                            e.FillRectangle(new SolidBrush(Color.FromArgb(a.Mypt.Intensity * 51, Color.DarkOrchid)), new Rectangle(a.Mypt.Cords.X, a.Mypt.Cords.Y, 3, 3));
                            setForm.SoundsOffOn();
                        }
                    }
                }

            };


        }

        void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(image, pictureBox1.Size);
                pictureBox1.Image = bmp;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Progress(int value)
        {
            progressBar1.Value = value;
        }

        private Point[] Converter(double[] xes, double[] ys)
        {
            double x1= 48.844643, y1 = 55.921823,
                   x2 = 49.356194, y2= 55.679063;
            int xmax = pictureBox1.Image.Width, ymax = pictureBox1.Image.Height;
            var ptsList = new List<Point>();
            for(int i=0;i<xes.Length;i++)
            {
                ptsList.Add(new Point((Convert.ToInt32(Math.Round((xmax * (xes[i] - x1) / (x2 - x1))))), 
                            (Convert.ToInt32(Math.Round(ymax * (ys[i] - y1) / (y2 - y1))))));
            }
            return ptsList.ToArray();
        }

        private void BtnInterpolation_Click(object sender, EventArgs e)
        {
            interForm.mpts = globalMyPointList.ToArray();
            try
            {  
                btnInterpolation.Enabled = false;
                bw.DoWork += (o, ev) =>
                {
                    interForm.myImage = (Bitmap)image;
                    interForm.BW_Methode1();
                    
                };
                bw.RunWorkerAsync();
                bw.RunWorkerCompleted += (o, ev) =>
                {
                    interForm.Show();
                    btnInterpolation.Enabled = true; 
                    setForm.SoundsOffOn();
                    progressBar1.Value = 0;
                };
            }
            catch (ObjectDisposedException ex)
            {
                label1.Text += ex.ToString();
            }
        }

        private void Btn_settings_Click(object sender, EventArgs e)
        {
            setForm.ShowDialog();
        }

        private void Flag_btn_server()
        {
            flag_btn_server = !flag_btn_server;
        }

        private void Btn_server_Click(object sender, EventArgs e)
        {
            if (flag_btn_server)
            {
                btn_server.Text = "Enable Server";
                label1.Text += " >> Server disabled\n";
                serverObject.ServerClose();
                Flag_btn_server();
            }
            else
            {
                listForm.Show();
                serverObject.xmax = pictureBox1.Width;
                serverObject.ymax = pictureBox1.Height;
                btn_server.Text = "Disable Server";
                serverObject.ServerTask();
                Flag_btn_server();
            }
                        
        }

        private async void Btn_print_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
                {
                    MyPoint[] newmp = serverObject.MegaGlobalMyPointList.ToArray();
                    foreach (MyPoint i in newmp)
                    {
                        if (label1.InvokeRequired)
                            label1.Invoke(new Action(() => { label1.Text = "Placement: " + i.Cords.ToString() + "; Intesity: " + i.Intensity.ToString() + "\n"; }));
                        else
                            label1.Text = "Placement: " + i.Cords.ToString() + "; Intesity: " + i.Intensity.ToString() + "\n";
                    }
                });
        }

        private void BtnCreateGraph_Click(object sender, EventArgs e)
        {
            graphicForm.Show();
        }

    }

    class FormEventArgs : EventArgs
    {
        public string IpAddress { get; set; }
        public FormEventArgs(string ipaddress)
        {
            IpAddress = ipaddress;
        }
    }


    public class MyPoint
    {
        public string Tracker { get; set; }
        public Point Cords { get; set; }
        public int Intensity { get; set; }
        public MyPoint(string tracker, int intensity, Point cords)
        {
            Tracker = tracker;
            Intensity = intensity;
            Cords = cords;
        }
    }

     static class Gen
     {
         public static int GRN(int min, int max)
         {
             RNGCryptoServiceProvider c = new RNGCryptoServiceProvider();
             byte[] randomNumber = new byte[4];
             c.GetBytes(randomNumber);
             int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));
             return result % max + min;
         }
     }

}