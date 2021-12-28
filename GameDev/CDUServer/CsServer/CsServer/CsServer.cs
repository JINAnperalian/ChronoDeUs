using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using CsServer.Entities;
using Newtonsoft.Json;

namespace CsServer
{
    public class CsServer
    {

        private Socket _socket;
        private readonly string _ip = "192.168.0.101";
        private const int Port = 9931;

        private IPAddress _ipAddress => IPAddress.Parse(_ip);
        private IPEndPoint _ipEndPoint;

        private Thread _serverThread;

        public CsServer()
        {
            _ipEndPoint = new IPEndPoint(IPAddress.Parse(_ip), Port);
        }
        
        private int InitServer()
        {
            // var i = typeof(CsServer).GetMethods()[0].GetCustomAttributes();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.Bind(_ipEndPoint);
            _serverThread = new Thread(_Run);

            var player = new Player();
            player.CallRpc("HelloWorld",new object[]{123});
            
            return 0;
        }
        
        public void Run()
        {
            InitServer();
            _serverThread.Start();
            while (true)
            {
                string? info = Console.ReadLine();
                if (info.Contains("exit"))
                {   
                    Console.WriteLine("Stop");
                    return;
                }
            }
        }

        private void _Run()
        {
            while (true)
            {
                var buffer = new byte[1024 * 1024];
                EndPoint iep = _ipEndPoint;
                var length=_socket.ReceiveFrom(buffer, ref iep);
                if (length!=0)
                {
                    string msg = Encoding.Default.GetString(buffer, 0, length);
                    List<object> d = JsonConvert.DeserializeObject<List<object>>(msg)!;
                    foreach (var item in d)
                    {
                        Console.WriteLine(item);
                    }
                }
                
            }
        }

        private void AcceptCallBack(IAsyncResult asyncResult)
        {
            Console.WriteLine(asyncResult.ToString());
            var length=_socket.EndAccept(asyncResult);
            
        }
    }
}