using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public class Server
{

    public Int32 port = 9090;
    public IPAddress localAddress;

    public bool running = true;

    public BaseEndpoint[] endpoints;

    private TcpListener server;

    public Server()
    {

        port = 9090;
        localAddress = IPAddress.Parse("127.0.0.1");

        server = new TcpListener(localAddress, port);

        endpoints = new BaseEndpoint[0];

    }

    public Server(int _port, string _ip)
    {

        port = _port;
        localAddress = IPAddress.Parse(_ip);

        server = new TcpListener(localAddress, port);

        endpoints = new BaseEndpoint[0];

    }

    public void AddEndpoint(BaseEndpoint endpoint)
    {

        List<BaseEndpoint> tempList = new List<BaseEndpoint>(endpoints);
        tempList.Add(endpoint);
        endpoints = tempList.ToArray();

    }

    public void LogRequest(Request input)
    {

        Console.WriteLine($"{input.RequestType} {input.RequestURI} {input.OmtpVersion}");
        foreach (KeyValuePair<string, string> kvp in input.Headers)
        {

            Console.WriteLine($"{kvp.Key}: {kvp.Value}");

        }

        Console.WriteLine();
        Console.WriteLine(input.Body);
        Console.WriteLine();

    }

    public Response QueryEndpoints(Request input)
    {

        // Return a 500 Response Code if Endpoints is null
        if (endpoints == null) return BasicResponse.InternalError();

        // Loop through the Endpoints
        for (int i = 0; i < endpoints.Length; i++)
        {

            // If an endpoint matches the criteria, run it
            if (endpoints[i].Query(input.RequestURI))
                return endpoints[i].Run(input);

        }

        // Return a 404 Response Code
        return BasicResponse.NotFound();

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
                LogRequest(req);

                // Interpret the Request 
                Response output = QueryEndpoints(req);
                string responseText = OmtpParser.ParseResponse(output);

                // Respond 
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(responseText);
                stream.Write(msg, 0, msg.Length);

            }

            // Close the Connection
            client.Close();

        }

        server.Stop();

    }

}