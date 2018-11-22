using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace ServerSide
{
    public partial class ChatForm : Form
    {
        public event Action<ChatFormArgs> SendMessage;
        public string[] myAr;
        public bool flag = false;
        public byte[] _buffer;
        
        public ChatForm()
        {
            InitializeComponent();
            FormClosing += ChatForm_FormClosing;
            richTextBox2.TextChanged += RichTextBox2_TextChanged;
            richTextBox2.Focus();
            Load += (o, e) => { flag = true; };
        }

        void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        void RichTextBox2_TextChanged(object sender, EventArgs e)
        {
            myAr = richTextBox2.Text.Split('\n');
            if (myAr[myAr.Length - 1] == "")
            {
                richTextBox1.Text += richTextBox2.Text;
                SendMessage?.Invoke(new ChatFormArgs(richTextBox2.Text));
                richTextBox2.Clear();
            }
        }
        
    }

    public class ChatFormArgs : EventArgs
    {
        public string Message { get; set; }
        public ChatFormArgs(string message)
        {
            Message = message;
        }
    }

}
