using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace dajeneznau
{
    class Server
    {
        SettingsForm setForm = new SettingsForm();
        public List<MyPoint> MegaGlobalMyPointList = new List<MyPoint>();
        public event Action<ServerArgs> ServerEvent;
        public event Action<ServerAgrs1> ServerEvent1;

        public static TcpListener serverSocket = new TcpListener(13000);
        private static int requestCount = 0;
        public static TcpClient clientSocket = default(TcpClient);
        public static byte[] bytesFrom = new byte[1024];
        public static string data = null;
        public static string serverResponse = null;
        public async Task ServerSetup()
        {
            try
            {
                await Task.Run(() =>
                {
                    serverSocket.Start();
                    IPHostEntry ip = Dns.GetHostEntry("");
                    ServerEvent.Invoke(new ServerArgs(" >> Server Started with address " + ip.AddressList[2].ToString() + "\n"));
                    requestCount += 1;

                    clientSocket = serverSocket.AcceptTcpClient();
                    string MYIpClient;
                    TcpClient client = clientSocket as TcpClient;
                    MYIpClient = Convert.ToString(((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address);
                    ServerEvent.Invoke(new ServerArgs("\r\n >> Accept connection from client"));
                    ServerEvent.Invoke(new ServerArgs("\r\n >> Connected from IP: " + MYIpClient));

                    NetworkStream networkStream = clientSocket.GetStream();
                    try
                    {
                        while ((networkStream.Read(bytesFrom, 0, bytesFrom.Length)) > 0)
                        {
                            List<byte> bytesFrom1 = new List<byte>();
                            for (int i = 0; i < bytesFrom.Length; i++)
                            {
                                if (bytesFrom[i] != 0)
                                {
                                    bytesFrom1.Add(bytesFrom[i]);
                                    bytesFrom[i] = 0;
                                }
                            }
                            byte[] bytesFrom2 = bytesFrom1.ToArray();
                            data = Encoding.ASCII.GetString(bytesFrom2, 0, bytesFrom2.Length);
                            //ServerEvent.Invoke(new ServerArgs(" >> Data from client - " + data));
                            serverResponse += data;
                            bytesFrom1 = null;
                            bytesFrom2 = null;

                            if (serverResponse.IndexOf("\r\n\r\n") >= 0 || serverResponse.Length > 8)
                            {
                                break;
                            }
                        }
                        string send = "data recieved\n";
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(send);
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();
                        ServerEvent.Invoke(new ServerArgs("\n >> Total infromation recievd:\n" + serverResponse));
                        string[] array = serverResponse.Split(',');
                        if (array.Length > 2)
                        {
                            MyPoint my = new MyPoint(Convert.ToInt16(array[0]), new Point(Convert.ToInt16(array[1]), Convert.ToInt16(array[2])));
                            ServerEvent1.Invoke(new ServerAgrs1(my));
                            MegaGlobalMyPointList.Add(my);
                        }
                        StreamWriter SW = new StreamWriter(new FileStream("serverResponse.txt", FileMode.Create, FileAccess.Write));
                        SW.Write("\r\n serverResponse: \n" + serverResponse);
                        SW.Close();
                        serverResponse = null;
                        data = null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    clientSocket.Close();
                    serverSocket.Stop();
                    setForm.SoundsOffOn();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task ServerClose()
        {
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                clientSocket.Close();
                serverSocket.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }

    class ServerArgs : EventArgs
    {
        public string Message { get; set; }
        
        public ServerArgs(string message)
        {
            Message = message; 
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
}
