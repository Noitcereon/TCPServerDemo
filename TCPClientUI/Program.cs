using System;
using TCPLib;

namespace TCPClientUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            SimpleMathClientWorker worker = new SimpleMathClientWorker();
            worker.Start();

            Console.ReadKey();
        }
    }
}
