using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPLib
{
    public class ServerWorker
    {
        public void Start()
        {
            // Create server
            // IP of own computer, port is type of application, which in this case is an echo server, hence port 7.
            TcpListener server = new TcpListener(IPAddress.Loopback, 7); // port 7 = echo server
            server.Start();
            
            while (true)
            {
                Console.WriteLine("Server ready.");
                // Waits for a client to call.
                TcpClient socket = server.AcceptTcpClient();

                DoClient(socket);
            }
        }

        public void DoClient(TcpClient socket)
        {
            StreamReader streamReader = new StreamReader(socket.GetStream());
            StreamWriter streamWriter = new StreamWriter(socket.GetStream());

            // Read text from client
            string str = streamReader.ReadLine();
            Console.WriteLine($"Server received content: {str?.ToUpper()}");

            // Write to back to the client
            streamWriter.WriteLine(str);
            streamWriter.Flush(); // empties buffer

            socket.Close();
        }
    }
}
