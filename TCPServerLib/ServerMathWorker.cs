using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib
{
    public class ServerMathWorker : IServerWorker
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 3002);
            server.Start();
            Console.WriteLine("Server ready.");
            while (true)
            {
                TcpClient tempSocket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    HandleClient(tempSocket);
                });
            }
        }


        private void HandleClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            string clientMsg = sr.ReadLine();
            Console.WriteLine($"Request: {clientMsg}");

            List<double> numbers = new List<double>();
            var splitStr = clientMsg?.Split(" ");
            if (splitStr == null) return;
            for (int i = 0; i < splitStr.Length; i++)
            {
                if (i == 0)
                {
                    if (splitStr[i].ToLower() != "ADD".ToLower()) break;
                }
                else
                {
                    numbers.Add(Double.Parse(splitStr[i], new CultureInfo("da-DK")));
                }
            }

            var output = numbers.Sum();

            sw.WriteLine($"Result: {output}");
            sw.Flush();

            socket.Close();
        }
    }
}
