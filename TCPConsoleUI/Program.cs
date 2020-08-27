using System;
using TCPLib;

namespace TCPServerUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServerWorker serverWorker = new ServerWorker();
            serverWorker.Start();

            Console.ReadLine();
        }
    }
}
