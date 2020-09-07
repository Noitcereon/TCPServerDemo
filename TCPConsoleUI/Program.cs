using System;
using TCPLib;

namespace TCPServerUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServerWorker serverWorker = new ServerMathWorker();
            serverWorker.Start();

            Console.ReadLine();
        }
    }
}
