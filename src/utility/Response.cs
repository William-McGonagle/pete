using System.Collections.Generic;

public struct Response
{

    public string OmtpVersion;
    public int ResponseCode;
    public string ResponseText;

    public Dictionary<string, string> Headers;

    public string Body;

}