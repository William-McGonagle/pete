using System;

public class FileEndpoint : BaseEndpoint
{

    string filePath = "";

    public FileEndpoint(string _filePath) : base("File Endpoint")
    {

        filePath = _filePath;

    }

    public override bool Query(string uri)
    {

        return uri == "/test";

    }

    public override Response Run(Request req)
    {

        return BasicResponse.NotFound();

    }

}