using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using SocketDocumentShareClient;
using System.Runtime.Serialization.Formatters.Binary;


namespace WindowsThread
{
    class ClientSocket
    {
        protected string path = "";
        protected Socket client;
        public bool ConnectionFailed = false;

        
        public ClientSocket()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.105"), 180));
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("连接服务器失败");
                Console.WriteLine("连接服务器失败");
                ConnectionFailed = true;
            }
            
        }
        public ClientSocket(string ip, int port)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //ip="192.168.1.105" port = 180
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接服务器失败");
                Console.WriteLine("连接服务器失败",ex);
                ConnectionFailed = true;
            }

        }
        
    }
    class ClientSocketSend : ClientSocket
    {
        public void sendMessage(object ft)
        {//客户端向服务端发送
            FileTransport fileToSend = ft as FileTransport;
            try
            {
                //fileToSend.returnFileStream();
                FileMemeber fm = new FileMemeber(fileToSend);
                
                byte[] b = SerializeNDeserialize.Serialize(fm);
                Console.WriteLine("长度是{0}", b.Length);
                
                client.Send(b);
                Console.WriteLine("正在发送信息{0}", fileToSend);

            }
            catch (Exception ex)
            {
                Console.WriteLine("客户端向服务端发送失败", ex);
            }
        }
    }

    class ClientSocketReceive : ClientSocket
    {
        
        private byte[] btToReceive = new byte[1024 * 1024 * 10];//10M
        public byte[] BtToReceive
        {
            get { return btToReceive; }
        }
        private byte[] btToReceiveList = new byte[100];
        public byte[] BtToReceiveList
        {
            get { return btToReceiveList; }
        }

        //读取请求-文件列表-文件-文件返回

        public ClientSocketReceive(string ip, int port) : base(ip, port) { }
        public void SendMessage(object ft)
        {
            try
            {
                byte[] btFileNeed = Encoding.UTF8.GetBytes(ft as string);
                client.Send(btFileNeed);
            }
            catch (Exception ex)
            {
                Console.WriteLine("客户端向服务端发送选择文件名失败", ex);
            }
        }
        public void sendRequest()
        {
            try
            {
                byte[] isRequesting = new byte[] { 1 };
                client.Send(isRequesting);
            }
            catch (Exception ex)
            {
                Console.WriteLine("客户端向服务端发送请求失败", ex);
            }
        }
        public void getMessageFromServer()
        {
            //从服务器接收信息
            int bytes = -1;
            //while (true)
            //{
                
                try
                {
                    bytes = client.Receive(btToReceiveList, btToReceiveList.Length, 0);
                    //if (bytes != -1)
                    //    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("从服务器接受列表信息失败：", ex);
                    //break;
                }
            //}

        }

        public void downloadFile()
        {
            //Socket serversocket = server as Socket;
            
            int bytes = -1;
            while (true)
            {
                //try
                //{
                    bytes = client.Receive(btToReceive, btToReceive.Length, 0);
                    if (bytes != -1)
                        break;
                    FileMemeber fm = SerializeNDeserialize.Deserialize(BtToReceive) as FileMemeber;
                    //这里要改存储位置
                    FileSavec.toFileSave(fm.BtFile, "C:/Users/李景阳/Pictures/新建文件夹 (2)", Encoding.UTF8.GetString(fm.BtFileName));
                //}

                //catch (Exception ex)
                //{
                //    Console.WriteLine("从服务器接受信息失败：", ex);
                //    break;
                //}
        }
            
        }
        
    }
}
