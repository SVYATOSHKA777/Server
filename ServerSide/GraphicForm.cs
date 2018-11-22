using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tao.FreeGlut;
using Tao.OpenGl;


namespace ServerSide
{
    public partial class GraphicForm : Form
    {
        Graphics graphic;
        Bitmap bitmap;
        public GraphicForm()
        {
            InitializeComponent();
            this.Load += GraphicForm_Load;
        }

        void GraphicForm_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphic = Graphics.FromImage((Image)bitmap);
            graphic.FillRectangle(new SolidBrush(Color.BlueViolet), 0, 0, pictureBox1.Width, pictureBox1.Height);
            graphic.DrawLine(new Pen(Color.Gold), 5, 5, 5, pictureBox1.Height);
            graphic.DrawLine(new Pen(Color.Gold), 5, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            pictureBox1.Image = bitmap;
        }
    }
}
