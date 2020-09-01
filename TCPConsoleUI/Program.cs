using System;
using TCPLib;

namespace TCPServerUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServerWorker serverWorker = new SimpleMathServerWorker();
            serverWorker.Start();

            Console.ReadLine();
        }
    }
}
