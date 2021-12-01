public class Server
{

    public int port = 9090;
    public string ip = "127.0.0.1";

    public Server()
    {

        port = 9090;
        ip = "127.0.0.1";

    }

    public Server(int _port, string _ip)
    {

        port = _port;
        ip = _ip;

    }

}