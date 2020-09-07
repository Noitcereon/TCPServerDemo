using System;
using TCPLib;

namespace TCPClientUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IClientWorker worker = new ClientWorker();
            worker.Start(3002);

            Console.ReadKey();
        }
    }
}
