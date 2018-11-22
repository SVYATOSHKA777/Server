using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ServerSide
{
    public partial class BrowserForm : Form
    {
        public double x1, y1,
                   x2, y2;
        double mX1,mX2,mY1,mY2;
        Rectangle rect;
        internal Size size;
        string xc, yc;
        public event Action<BrowserFormEventArgs> BrowserEvent;
        Bitmap prntScrn = new Bitmap(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);
        public BrowserForm()
        {
            InitializeComponent();
            this.Size = SystemInformation.PrimaryMonitorSize;
            this.Shown += BrowserForm_Shown;
            this.webBrowser1.Navigated += WebBrowser1_Navigated;
            this.webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Timer myTimer = new Timer();
            myTimer.Interval = 1;
            myTimer.Start();
            myTimer.Tick += ((a, k) =>
            {
                try
                {
                    Graphics myGraphic = Graphics.FromImage(prntScrn);
                    myGraphic.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);
                    prntScrn = prntScrn.Clone(new Rectangle(0, 100, prntScrn.Size.Width, prntScrn.Size.Height - 160), prntScrn.PixelFormat);
                    prntScrn.Save(System.IO.Directory.GetCurrentDirectory() + @"\" + "prntScrn.jpg", System.Drawing.Imaging.ImageFormat.Bmp);
                    myTimer.Stop();
                    this.Close();
                    System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            });
        }

        void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {

        }
        private string ZoomAddition()
        {
            double sub = (y2 - y1)/(Screen.PrimaryScreen.Bounds.Height*0.002988941);
            if (sub - (10e-3) > 1)
            {
                int q = (int)Math.Ceiling(sub);
                return Convert.ToString((2 * q - 2));
            }
            else
            {
                if (sub - (10e-3) < 1)
                {
                    int q = (int)Math.Ceiling(sub);
                    return Convert.ToString(-1 * (2 * q - 2));
                }
                else
                    return "0";
            }
        }

        void BrowserForm_Shown(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() =>
                    {
                        yc = Convert.ToString(0.5 * y1 + 0.5 * y2);
                        xc = Convert.ToString(0.5 * x1 + 0.5 * x2);

                        mX1 = (x1 + x2) / 2 - 0.5 * (prntScrn.Width / 334.5666378);
                        mX2 = (x1 + x2) / 2 + 0.5 * (prntScrn.Width / 334.5666378);
                        mY1 = (y1 + y2) / 2 - 0.5 * ((prntScrn.Height - 100) / 1186.378221);
                        mY2 = (y1 + y2) / 2 + 0.5 * ((prntScrn.Height - 260) / 1186.378221);

                        int resx1 = (int)(0.5*(x1 - mX1) * 334.5666378);
                        int resx2 = Screen.PrimaryScreen.Bounds.Size.Width / 2 + (int)(((x2 - x1) /2) * 334.5666378);
                        int resy1 = (int)(0.5*(y1 - mY1) * 1186.378221);
                        int resy2 = Screen.PrimaryScreen.Bounds.Size.Height / 2 + (int)(((y2 - y1)/2 ) * 1186.378221);
                        size = prntScrn.Size;
                        BrowserEvent.Invoke(new BrowserFormEventArgs(mX1, mX2, mY1, mY2));
                        rect = new Rectangle(resx1, resy1, resx2, resy2);
                        string httpAddress = "https://www.google.ru/maps/@" + yc + "," + xc + ",10z";
                        webBrowser1.Navigate(httpAddress);
                    });
            }
            catch (FormatException ex)
            {
                Excpn_lbl.Font = new System.Drawing.Font("TimesNewRoman" ,20f);
                Excpn_lbl.Text = "Invalid input data. Input data must have next format: X.XXXXXX, Y.YYYYYY";
            }
        }
    }


    public class BrowserFormEventArgs : EventArgs
    {
        public double mX1 { get; set; }
        public double mX2 { get; set; }
        public double mY1 { get; set; }
        public double mY2 { get; set; }
        public BrowserFormEventArgs(double mx1, double mx2, double my1, double my2)
        {
            mX1 = mx1;
            mX2 = mx2;
            mY1 = my1;
            mY2 = mY2;
        }
    }
}
