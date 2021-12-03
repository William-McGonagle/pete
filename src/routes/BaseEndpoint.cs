public class BaseEndpoint
{

    public string name = "Base Endpoint";

    public BaseEndpoint(string _name)
    {

        name = _name;

    }

    public virtual bool Query(string uri)
    {

        return false;

    }

    public virtual Response Run(Request req)
    {

        return new Response();

    }

}