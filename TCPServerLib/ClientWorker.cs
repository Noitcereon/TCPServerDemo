using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPLib
{
    public class ClientWorker
    {
        public void Start()
        {
            // Client connects to the server, which in this case is localhost on port 7.
            TcpClient client = new TcpClient("127.0.0.1", 7);

            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            string outputToServer = "This is the client speaking: hello! :p";
            sw.WriteLine(outputToServer);
            sw.Flush();

            string inputFromServer = sr.ReadLine();
            Console.WriteLine($"Server's response: {inputFromServer}");

            client.Close();
        }
     
    }
}
