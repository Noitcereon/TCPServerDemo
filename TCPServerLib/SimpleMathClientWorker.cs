using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPLib
{
    public class SimpleMathClientWorker
    {
        public void Start()
        {
            TcpClient client = new TcpClient("localhost", 3001);

            DoClient(client);
        }

        private void DoClient(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            sw.WriteLine("ADD 5 8");
            sw.Flush();

            Console.WriteLine($"Server response: {sr.ReadLine()}");

            client.Close();
        }
    }
}
