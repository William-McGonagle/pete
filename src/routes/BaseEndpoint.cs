public class BaseEndpoint
{

    public string name = "Base Endpoint";

    /// <summary>
    /// The base endpoint constructor.
    /// </summary>
    /// <param name="_name">The name of the endpoint type.</param>
    public BaseEndpoint(string _name)
    {

        name = _name;

    }

    /// <summary>
    /// Check if the request's url matches the endpoint's url.
    /// </summary>
    /// <param name="uri">The request's url.</param>
    /// <returns>Whether or not the request's url matches the endpoint's url.</returns>
    public virtual bool Query(string uri)
    {

        return false;

    }

    /// <summary>
    /// Runs the file endpoint.
    /// </summary>
    /// <param name="req">The request data.</param>
    /// <returns>The response that the file endpoint produced.</returns>
    public virtual Response Run(Request req)
    {

        return new Response();

    }

}