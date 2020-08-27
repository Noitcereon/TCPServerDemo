using System;
using TCPLib;

namespace TCPClientUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ClientWorker worker = new ClientWorker();
            worker.Start();

            Console.ReadLine();
        }
    }
}
