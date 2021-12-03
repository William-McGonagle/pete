using System.Collections.Generic;

public struct Request
{

    public string RequestType;
    public string OmtpVersion;
    public string RequestURI;

    public Dictionary<string, string> Headers;

    public string Body;

}