using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace ServerSide
{
    public class StateObject
    { 
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize]; 
        public StringBuilder sb = new StringBuilder();
    }
    public delegate void EventSignature(EventArgs e);
    class Server
    {
        private int i = 0;
        internal int xmax,ymax;
        double xMin, xMax, yMin, yMax;
        public event Action<ClientArgs> ServerEvent;
        public event Action<ServerAgrs1> ServerEvent1;
        public event Action<ClientArgs> ListEvent;
        public event Action<ListEventAgrs> ChatListEvent;
        public event EventSignature MyEvent;

        byte[] by = new byte[1024];
        string DecrypedData = "";
        public List<MyPoint> MegaGlobalMyPointList = new List<MyPoint>();
        private static byte[] _buffer = new byte[1024];
        private static string dataRecieved;
        int socketsCount = 0;

        ListForm listForm = new ListForm();
        EncryptionClass EncrObj = new EncryptionClass();
        EventClass eventClass = new EventClass();
        SettingsForm setForm = new SettingsForm();
        BrowserForm browser = new BrowserForm();

        public string ipAdr = "0";
        public string listIPAddress = "";
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void ListMethode(string ipAddress)
        {
            ChatListEvent.Invoke(new ListEventAgrs(ipAddress));
        }

        public Server()
        {
            browser.BrowserEvent += a => { xMin = a.mX1; xMax = a.mX2; yMin = a.mY1; yMax = a.mY2; };
        }
        public void ServerTask()
        {
            SetupServer();
        }
        private void SetupServer()
        {
            ServerEvent.Invoke(new ClientArgs(" >> Settuping up server... \n"));
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 13000));
            _serverSocket.Listen(100);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);

        }

        private void AcceptCallBack(IAsyncResult AR)
        {
            try
            {
                Socket socket = _serverSocket.EndAccept(AR);
                _clientSockets.Add(socket);
                ipAdr = socket.RemoteEndPoint.ToString();
                ListEvent.Invoke(new ClientArgs(ipAdr));
                listForm.listBox1.Items.Add(ipAdr);

                //ChatForm Task
                Task.Run(() =>
                {
                    ChatForm chatForm = new ChatForm();
                    string chatFormTextIP = ipAdr;
                    chatForm.groupBox1.Text = "Chat with " + ipAdr;
                    SendData(socket, EncrObj.PublicKey);
                    chatForm.richTextBox2.TextChanged += (o, ev) =>
                        {
                            //Chat Handler
                            chatForm.myAr = chatForm.richTextBox2.Text.Split('\n');
                            if (chatForm.myAr[chatForm.myAr.Length - 1] == "")
                            {
                                chatForm.richTextBox1.Text += ">>Server: "+chatForm.richTextBox2.Text;
                                SendData(socket, chatForm.richTextBox2.Text + "\n");
                                chatForm.richTextBox2.Clear();
                            }
                        };
                    ChatListEvent += (arg) =>
                    {
                        if (arg.ListString == chatFormTextIP)
                        {
                           chatForm.Show();
                        }
                    };
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBAck), socket);
                    MyEvent += (e) =>
                    {
                        DecrypedData = EncrObj.Decrypt(by);
                        if (chatForm.richTextBox1.InvokeRequired)
                            chatForm.richTextBox1.Invoke(new Action(() =>
                                {
                                    chatForm.richTextBox1.Text += ">>Client: " + Encoding.ASCII.GetString(by) + "\n";
                                }));
                        else
                            chatForm.richTextBox1.Text += ">>Client: " + Encoding.ASCII.GetString(by) + "\n";
                    };
                });

                ServerEvent.Invoke(new ClientArgs(" >> Client connects\n"));
                ServerEvent.Invoke(new ClientArgs(socket.RemoteEndPoint.ToString() + "\n"));
                socketsCount++;
                StateObject state = new StateObject();
                
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ReceiveCallBAck(IAsyncResult AR)
        {
            try
            {
                Func<byte, bool> predicate = x => x == 0;
                by = _buffer.Reverse().SkipWhile(predicate).Reverse().ToArray();
                Socket socket = (Socket)AR.AsyncState;
                ServerEvent.Invoke(new ClientArgs(IsSocketConnected(socket)));
                int received = socket.EndReceive(AR);
                byte[] dataBuf = new byte[received];
                Array.Copy(_buffer, dataBuf, received);
                string text = Encoding.ASCII.GetString(dataBuf);
                dataRecieved = text;
                string ipAdr = socket.RemoteEndPoint.ToString();

                if (MyEvent != null)
                    MyEvent.Invoke(EventArgs.Empty);
                ServerEvent.Invoke(new ClientArgs(" >> Data received: " + DecrypedData + "from " + ipAdr + "\n"));
                string response = string.Empty;

                byte[] data = Encoding.ASCII.GetBytes(response);
                if (DecrypedData.Contains(","))
                {
                    string[] array = DecrypedData.Split(',');
                    if (array.Length > 3)
                    {
                        Point pixelPoint = new Point(Convert.ToInt32(Math.Round((xmax * (Convert.ToDouble(array[3]) - xMin) / (xMax - xMin)))),
                                (ymax - Convert.ToInt32(Math.Round(ymax * (Convert.ToDouble(array[2]) - yMin) / (yMax - yMin)))));
                        MyPoint my = new MyPoint(array[0], Convert.ToInt16(array[1]), pixelPoint);
                        ServerEvent1.Invoke(new ServerAgrs1(my));
                        MegaGlobalMyPointList.Add(my);
                    }
                }
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                SendData(socket, "hello\n");
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBAck), socket);
                setForm.SoundsOffOn();
                i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void SendData(Socket handler, string text)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(text);
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        public void SendData(Socket handler, byte[] publicKey)
        {
            handler.BeginSend(publicKey, 0, publicKey.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult AR)
        {
            try
            {
                Socket socket = (Socket)AR.AsyncState;
                socket.EndSend(AR);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ServerClose()
        {
            _serverSocket.Close();
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        static bool IsSocketConnected(Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
        }

    }
    class ClientArgs : EventArgs
    {
        public string Message { get; set; }
        public Socket Soket { get; set; }
        public byte[] DataTransfered { get; set; }
        public bool Flag { get; set; }
        public ClientArgs(bool flag)
        {
            Flag = flag;
        }
        public ClientArgs(string message)
        {
            Message = message;
        }

        public ClientArgs(Socket socket)
        {
            Soket = socket;
        }

        public ClientArgs(byte[] dataTransfered)
        {
            DataTransfered = dataTransfered;
        }
    }

    class ServerAgrs1 : EventArgs
    {
        public MyPoint Mypt { get; set; }

        public ServerAgrs1(MyPoint mypt)
        {
            Mypt = mypt;
        }

    }

    class ListEventAgrs : EventArgs
    {
        public string ListString { get; set; }
        public ListEventAgrs(string listString)
        {
            ListString = listString;
        }
    }

    class EventClass
    {
        int var;
        public int Var
        {
            get { return var; }
            set
            {
                if (OnVarChanged != null) OnVarChanged(EventArgs.Empty);
                var = value;
            }
        }
        public delegate void EventSignature(EventArgs e);
        public event EventSignature OnVarChanged;
    }
}
