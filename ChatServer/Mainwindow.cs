using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace ChatServer
{

    public partial class Mainwindow : Form
    {
        private int PortNumber = 1234;
        private Socket ServerSocket = null;
        private IPEndPoint endPoint = null;
        private bool ServerState = false;
        private Thread Listeningthread = null;
        private string message = "";
        Socket ClientSocket = null;
        Dictionary<string, Socket> connected = new Dictionary<string, Socket>();
        Dictionary<string, string> connectednickname = new Dictionary<string, string>();
        private bool inited = false;
        public Mainwindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 开启关闭监听ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ServerState)
            {
                if (!inited)
                {
                    ServerState = StartSocket();
                    ServerSocket.Bind(endPoint);
                    ServerSocket.Listen(100);
                    if (ServerState)
                    {
                        Listeningthread = new Thread(new ThreadStart(Listening));
                        Listeningthread.IsBackground = true;
                        Listeningthread.Start();
                        maintextbox.AppendText(DateTime.Now.ToString() + ":\r\n  服务启动成功！开始监听！\r\n");
                        inited = true;

                    }
                    else
                    {
                        maintextbox.AppendText(DateTime.Now.ToString() + ":\r\n  服务启动失败！返回代码：03\r\n");
                    }
                }
                else
                {
                    ServerState = true;
                }
            }
            else
            {
                ServerState = false;

            }

        }

        private void 端口设定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPort SetPortForm1 = new SetPort(this);
            SetPortForm1.ShowDialog();
        }
        public void Setport(int port)
        {
            PortNumber = port;
        }
        private bool StartSocket()
        {
            try
            {
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception)
            {
                MessageBox.Show("服务启动失败！返回代码：01");
                return false;
            }
            try
            {
                endPoint = new IPEndPoint(IPAddress.Loopback, PortNumber);
            }
            catch (Exception)
            {
                MessageBox.Show("服务启动失败！返回代码：02");
                return false;

            }


            return true;
        }

        private void showmessage(Object obj)
        {
            MessageBox.Show((String)obj);
        }



        private void closeconnect(Object socketforclient)
        {
            Socket socket = (Socket)socketforclient;


            socket.Disconnect(false);
            maintextbox.Invoke(new EventHandler(delegate
            {
                string nickname = null;
                connectednickname.TryGetValue(socket.RemoteEndPoint.ToString(), out nickname);
                maintextbox.AppendText(DateTime.Now.ToString() + ":\r\n  用户:" + socket.RemoteEndPoint.ToString() + "离开了服务器。\r\n\r\n");
            }));
            socket.Disconnect(false);
            connected.Remove(socket.RemoteEndPoint.ToString());
            connectednickname.Remove(socket.RemoteEndPoint.ToString());
        }
        private void recvmessages(Object socketforclient)
        {
            Socket socket = (Socket)socketforclient;
            while (ServerState && !socket.Poll(1000, SelectMode.SelectRead))
            {
                byte[] originalmseeage = new byte[4096];


                if (socket != null && socket.Connected)
                {
                    try
                    {
                        int len = socket.Receive(originalmseeage);

                        if (len > 0)
                        {
                            message = Encoding.Unicode.GetString(originalmseeage);
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(message);
                            XmlNode root = xmlDocument.SelectSingleNode("/Message");
                            if (message.Substring(0, 30) == "%%system%%endsession%%system%%")
                            {
                                break;
                            }
                            maintextbox.Invoke(new EventHandler(delegate
                            {
                                string nickname = null;
                                connectednickname.TryGetValue(socket.RemoteEndPoint.ToString(), out nickname);
                                maintextbox.AppendText
                                (DateTime.Now.ToString()
                                + "\r\n  "
                                + nickname
                                + " 对 "
                                + root.SelectSingleNode("Receiver").InnerText
                                + " 说: " + root.SelectSingleNode("Message").InnerText);
                                maintextbox.AppendText(Environment.NewLine);

                            }));

                        }
                        else
                        {

                        }
                    }
                    catch (Exception)
                    {


                    }
                }
            }
            closeconnect(socket);

        }
        private void Listening()
        {
            Random rd = new Random();
            int id = rd.Next(1, Int16.MaxValue);
            while (ServerState)
            {

                try
                {
                    ClientSocket = ServerSocket.Accept();

                }
                catch (Exception)
                {
                    continue;
                }
                
                foreach (var item in connected)
                {
                    string temp;
                    connectednickname.TryGetValue(item.Key,out temp);


                    XmlDocument xml = new XmlDocument();
                    //加入XML的声明段落：<?xmlversion="1.0" encoding="utf-8"?>
                    XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                    xml.AppendChild(xmldecl);
                    XmlElement root = xml.CreateElement("Message");
                    xml.AppendChild(root);
                    XmlElement eType = xml.CreateElement("Type");
                    eType.InnerText = "NewUser";
                    XmlElement eSender = xml.CreateElement("Sender");
                    eSender.InnerText = "system";
                    XmlElement eMessage = xml.CreateElement("Message");
                    eMessage.InnerText = temp;
                    XmlElement eTime = xml.CreateElement("Time");
                    eTime.InnerText = DateTime.Now.ToString();
                    root.AppendChild(eType);
                    root.AppendChild(eSender);
                    root.AppendChild(eMessage);
                    root.AppendChild(eTime);





                    string temp2 = xml.InnerXml;
                    ClientSocket.Send(Encoding.Unicode.GetBytes(xml.InnerXml));
                }
                Random rd1 = new Random(id);
                id = rd1.Next(1, Int16.MaxValue);
                connected.Add(ClientSocket.RemoteEndPoint.ToString(), ClientSocket);
                connectednickname.Add(ClientSocket.RemoteEndPoint.ToString(), "用户" + id.ToString());
                Thread recvt = new Thread(recvmessages);
                recvt.IsBackground = true;
                recvt.Start(ClientSocket);

                maintextbox.Invoke(new EventHandler(delegate
                {
                    maintextbox.AppendText(DateTime.Now.ToString() + ":\r\n  用户:" + ClientSocket.RemoteEndPoint.ToString() + "连接服务器。\r\n\r\n");
                    foreach (var item in connected)
                    {



                        XmlDocument xml = new XmlDocument();
                        
                        XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                        xml.AppendChild(xmldecl);
                        XmlElement root = xml.CreateElement("Message");
                        xml.AppendChild(root);
                        XmlElement eType = xml.CreateElement("Type");
                        eType.InnerText = "NewUser";
                        XmlElement eSender = xml.CreateElement("Sender");
                        eSender.InnerText = "system";
                        XmlElement eMessage = xml.CreateElement("Message");
                        eMessage.InnerText = "用户" + id.ToString();
                        XmlElement eTime = xml.CreateElement("Time");
                        eTime.InnerText = DateTime.Now.ToString();
                        root.AppendChild(eType);
                        root.AppendChild(eSender);
                        root.AppendChild(eMessage);
                        root.AppendChild(eTime);





                        string temp2 = xml.InnerXml;
                        item.Value.Send(Encoding.Unicode.GetBytes(xml.InnerXml));
                    }
                }));
                




            }
        }





    }
}
