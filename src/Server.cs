using System;
using System.Net;
using System.Net.Sockets;

public class Server
{

    public Int32 port = 9090;
    public IPAddress localAddress;

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



    }

}