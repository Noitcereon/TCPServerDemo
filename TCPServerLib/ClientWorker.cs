using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPLib
{
    public interface IClientWorker
    {
        void Start();
        void Start(int port);
    }

    public class ClientWorker : IClientWorker
    {
        public void Start()
        {
            // Client connects to the server, which in this case is localhost on port 7.
            TcpClient socket = new TcpClient("127.0.0.1", 7);

            DoClient(socket);
        }

        public void Start(int port)
        {
            TcpClient socket = new TcpClient("127.0.0.1", port);

            DoClient(socket);
        }

        private void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            Console.Write("Enter your message: ");
            string outputToServer = Console.ReadLine();
            sw.WriteLine(outputToServer);
            sw.Flush();

            string inputFromServer = sr.ReadLine();
            Console.WriteLine($"Server's response: {inputFromServer}");

            socket.Close();
        }
    }
}
