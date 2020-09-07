using System;
using System.Collections.Generic;
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

            Task.Run(() =>
            {
                TcpClient tempSocket = server.AcceptTcpClient();
                HandleClient(tempSocket);
            });

        }


        private void HandleClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            string clientMsg = sr.ReadLine();
            Console.WriteLine(clientMsg);

            List<double> numbers = new List<double>();
            var splitStr = clientMsg?.Split(" ");
            if (splitStr == null) return;
            for (int i = 0; i < splitStr.Length; i++)
            {
                if (splitStr[i].ToLower() != "ADD".ToLower()) break;
                if (i == 0) continue;

                numbers.Add(Convert.ToDouble(splitStr[i]));
            }

            var output = numbers.Sum();

            sw.WriteLine($"Result: {output}");
            sw.Flush();

            socket.Close();
        }
    }
}
