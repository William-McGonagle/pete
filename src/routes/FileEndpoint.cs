using System;
using System.IO;

public class FileEndpoint : BaseEndpoint
{

    string filePath = "";
    string url = "";

    /// <summary>
    /// The file endpoint constructor. 
    /// </summary>
    /// <param name="_url">The url of the endpoint.</param>
    /// <param name="_filePath">The path to the file on the system.</param>
    /// <returns>A new file endpoint.</returns>
    public FileEndpoint(string _url, string _filePath) : base("File Endpoint")
    {

        url = _url;
        filePath = _filePath;

    }

    /// <summary>
    /// Check if the request's url matches the endpoint's url.
    /// </summary>
    /// <param name="uri">The request's url.</param>
    /// <returns>Whether or not the request's url matches the endpoint's url.</returns>
    public override bool Query(string uri)
    {

        return uri == url;

    }

    /// <summary>
    /// Runs the file endpoint.
    /// </summary>
    /// <param name="req">The request data.</param>
    /// <returns>The response that the file endpoint produced.</returns>
    public override Response Run(Request req)
    {

        // Create a new Response
        Response output = BasicResponse.Okay();

        // Set the Body Equal to the Text File Data
        output.Body = File.ReadAllText(filePath);

        // Return the Text File
        return output;

    }

}