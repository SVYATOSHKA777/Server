using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ServerSide
{
    public partial class InterpolationForm : Form
    {
        public event Action<InterpolationArgs> InterAction;
        SettingsForm setForm = new SettingsForm();
        internal MyPoint[] mpts;
        Pt pt = new Pt();
        public int max;
        public Bitmap myImage;
        public InterpolationForm()
        {
            InitializeComponent();
            FormClosing += InterpolatioForm_FormClosing;
            Resize += InterpolatioForm_Resize;
            max =  pctrboxInterpolation.Width;
            
        }

        void InterpolatioForm_Resize(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(pctrboxInterpolation.Image, pctrboxInterpolation.Size);
                pctrboxInterpolation.Image = bmp;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void MyImage(Image myimage)
        {
            myImage = new Bitmap(myimage);
        }

        public void BW_Methode1()
        {
            try
            {
                
                Interpolation();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private void Interpolation()
        {
            int n = mpts.Length;
            double ro = 0.2 * pt.Lenght(new Point(myImage.Height, myImage.Width), pt.Zero);
            Bitmap newImage = new Bitmap(myImage, pctrboxInterpolation.Size);
            double lenght;
            Graphics graphic = Graphics.FromImage(newImage);
            double a = 0, b = 0;
            int intens = 0;
            var stop = new Stopwatch();
            stop.Start();
            for (int j = 0; j < newImage.Width; j += 1)
            {
                for (int i = 0; i < newImage.Height; i += 1)
                {
                    Point npt = new Point(j, i);
                    for (int k = 0; k < n - 1; k++)
                    {
                        lenght = pt.Lenght(npt, mpts[k].Cords);
                        if (ro - lenght > 0 && npt != mpts[k].Cords)
                        {
                            a += Math.Pow(ro - lenght, 4) * mpts[k].Intensity;
                            b += Math.Pow(ro - lenght, 4);
                        }
                    }
                    intens = (int)Math.Round(a / b);
                    a = 0;
                    b = 0;
                    graphic.FillRectangle(new SolidBrush(Color.FromArgb(intens * 51, Color.DarkOrchid)), new Rectangle(npt.X, npt.Y, 1, 1));
                    intens = 0;
                }
                InterAction.Invoke(new InterpolationArgs(1));
            }
            pctrboxInterpolation.Image = newImage;
            stop.Stop();
            label1.Text = "Elaspsed time(sec): " + (stop.ElapsedMilliseconds / 1000).ToString();
        }


        public void InterpolatioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            MyImage(ServerSide.Properties.Resources.THE_MAP);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                MyImage(ServerSide.Properties.Resources.THE_MAP);
                e.Cancel = true;
                Hide();
            }
        }
    }
    public class InterpolationArgs : EventArgs
    {
        public int Value { get; set; }
        public InterpolationArgs(int value)
        {
            Value = value;
        }
    }
}
