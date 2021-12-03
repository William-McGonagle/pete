using System;
using System.IO;

public class FileEndpoint : BaseEndpoint
{

    string filePath = "";
    string url = "";

    public FileEndpoint(string _url, string _filePath) : base("File Endpoint")
    {

        url = _url;
        filePath = _filePath;

    }

    public override bool Query(string uri)
    {

        return uri == url;

    }

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