using System;
using TCPLib;

namespace TCPConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServerWorker serverWorker = new ServerWorker();
            ClientWorker clientWorker = new ClientWorker();
            serverWorker.Start();
            //clientWorker.Start();


            Console.ReadLine();
        }
    }
}
