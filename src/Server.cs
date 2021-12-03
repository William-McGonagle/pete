using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public class Server
{

    public Int32 port = 9090;
    public IPAddress localAddress;

    public bool running = true;

    private TcpListener server;

    public Server()
    {

        port = 9090;
        localAddress = IPAddress.Parse("127.0.0.1");

        server = new TcpListener(localAddress, port);

    }

    public Server(int _port, string _ip)
    {

        port = _port;
        localAddress = IPAddress.Parse(_ip);

        server = new TcpListener(localAddress, port);

    }

    public void Listen()
    {

        server.Start();

        Byte[] bytes = new Byte[256];
        String data = null;

        while (running)
        {

            // WARNING: Blocking Call
            TcpClient client = server.AcceptTcpClient();

            data = null;

            // Get the Stream Object
            NetworkStream stream = client.GetStream();

            // Read Stream into bytes
            int state = 0;
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {

                // Get Data as String
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                // Parse the Request
                Request req = OmtpParser.ParseRequest(data, ref state);

                // Log the Request
                Console.WriteLine("Type: " + req.RequestType);
                Console.WriteLine("Path: " + req.RequestURI);
                Console.WriteLine("Version: " + req.OmtpVersion);

                Console.WriteLine("HEADERS");

                foreach (KeyValuePair<string, string> kvp in req.headers)
                {

                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");

                }

                // Respond 
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);

            }

            // Close the Connection
            client.Close();

        }

        server.Stop();

    }

}