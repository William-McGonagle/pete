using System;

namespace pete
{
    class Program
    {
        static void Main(string[] args)
        {

            // Speed Test
            string input = "GET /test OMTP/0.9\ntest: testing";

            int total = 0;
            for (int n = 0; n < 10; n++)
            {

                var watch = new System.Diagnostics.Stopwatch();

                watch.Start();

                for (int i = 0; i < 1000000; i++)
                {

                    int state = 0;
                    OmtpParser.ParseRequest(input, ref state);

                }

                watch.Stop();

                Console.WriteLine($"{watch.ElapsedMilliseconds} ms");

                total += (int)watch.ElapsedMilliseconds;

            }

            Console.WriteLine($"AVERAGE: {total / 10} ms");

            // // Create a New Server
            // Server server = new Server(9090, "127.0.0.1");

            // // Add Room Data
            // server.AddEndpoint(new FileEndpoint("./Program.cs"));

            // // Make Server Listen
            // server.Listen();

        }
    }
}
