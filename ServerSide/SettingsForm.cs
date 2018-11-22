using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ServerSide
{
    public partial class SettingsForm : Form
    {
        public event Action<SettingFormArgs> SettingAction;
        BrowserForm bwForm = new BrowserForm();
        public Bitmap bitmap;
        double xMin, yMin, xMax, yMax;
        internal double[] array = new double[4];

        internal double[] GlobalMapCoord = new double[2];
        BackgroundWorker bw = new BackgroundWorker();
        OpenFileDialog open = new OpenFileDialog();
        public SettingsForm()
        {
            InitializeComponent();
            open.Filter = "Images' Files: (*.jpg; *.jpeg; *.bmp; *.gif; *.png)|*.jpg; *.jpeg; *.bmp; *.gif; *.png";
            listBox1.Items.Add(ServerSide.Properties.Resources.THE_MAP);
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            textBox1.TextChanged += TextBox1_TextChanged;
            textBox2.TextChanged += TextBox2_TextChanged;
            textBox3.TextChanged += TextBox3_TextChanged;
            textBox4.TextChanged += TextBox4_TextChanged;
            FormClosing += (o, e) =>
            {
                try
                {
                    GlobalMapCoord[0] = Convert.ToDouble(textBox3.Text) / 2 + Convert.ToDouble(textBox1.Text) / 2;
                    GlobalMapCoord[1] = Convert.ToDouble(textBox4.Text) / 2 + Convert.ToDouble(textBox2.Text) / 2;
                }
                catch(Exception ex){}
            };
        }

        void TextBox4_TextChanged(object sender, EventArgs e)
        {
            bwForm.y2 = Convert.ToDouble(textBox4.Text);
            yMax = Convert.ToDouble(textBox4.Text); 
        }

        void TextBox3_TextChanged(object sender, EventArgs e)
        {
            bwForm.x2 = Convert.ToDouble(textBox3.Text);
            xMax = Convert.ToDouble(textBox3.Text);
        }

        void TextBox2_TextChanged(object sender, EventArgs e)
        {
            bwForm.y1 = Convert.ToDouble(textBox2.Text);
            yMin = Convert.ToDouble(textBox2.Text);
        }

        void TextBox1_TextChanged(object sender, EventArgs e)
        {
            bwForm.x1 = Convert.ToDouble(textBox1.Text);
            xMin = Convert.ToDouble(textBox1.Text);
        }

        void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem is String)
                {
                    bitmap = new Bitmap((string)listBox1.SelectedItem);
                }
                else
                    bitmap = new Bitmap((Bitmap)listBox1.SelectedItem);

                SettingAction.Invoke(new SettingFormArgs(bitmap));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Chkbx_sound_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void SoundsOffOn()
        {
            if (chkbx_sound.Checked)
            {
                SystemSounds.Beep.Play();
            }
        }

        public bool DrawingOffOn()
        {
            if (chkbx_draw.Checked)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open.ShowDialog();
            listBox1.Items.Add(open.FileName);
        }

        private void Brwsr_btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(System.IO.Directory.GetCurrentDirectory() + @"\" + "prntScrn.jpg");
            bwForm.ShowDialog();
        }

        internal void MapBorders()
        {
            double[] array = new double[4];
            array[0] = (xMin + xMax) / 2 - 0.5 * (bwForm.size.Width / 334.5666378);
            array[1] = (xMin + xMax) / 2 + 0.5 * (bwForm.size.Width / 334.5666378);
            array[2] = (yMin + yMax) / 2 - 0.5 * ((bwForm.size.Height - 100) / 1186.378221);
            array[3] = (yMin + yMax) / 2 + 0.5 * ((bwForm.size.Height - 260) / 1186.378221);
        }



    }
    public class SettingFormArgs : EventArgs
    {
        public Bitmap Picture { get; set; }

        public SettingFormArgs(Bitmap bitmap)
        {
            Picture = bitmap;
        }
    }
}
