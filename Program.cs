using System;

namespace pete
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a New Server
            Server server = new Server(9090, "127.0.0.1");

            // Add Room Data
            server.AddEndpoint(new FileEndpoint("/test", "./Program.cs"));

            // Make Server Listen
            server.Listen();

        }
    }
}
