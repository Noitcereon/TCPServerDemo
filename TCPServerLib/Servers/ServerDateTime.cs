using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.Servers
{
    public class ServerDateTime : IServerWorker
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 3003);
            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() => HandleClient(socket));
            }
        }

        private void HandleClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            string clientMsg = sr.ReadLine();

            sw.WriteLine("output");
            sw.Flush();

            socket.Close();
        }
    }
}
