using System;
using System.Threading;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(() => new Server(8976)).Start();
        }
    }
}
