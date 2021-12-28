using System;

namespace CsServer
{
    internal static class Program
    {
        private static readonly CsServer Server = new CsServer();
        static int Main(string[] args)
        {
            StartServer();
            return 0;
        }

        static void StartServer()
        {
            Server.Run();
        }
    }
}
