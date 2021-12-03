using System.Collections.Generic;

public class BasicResponse
{

    public const string OMTP_VERSION = "OMTP/0.9";

    public static Response Okay()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 200;
        output.ResponseText = "OK";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    public static Response NotFound()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 404;
        output.ResponseText = "Not Found";

        output.Headers = new Dictionary<string, string>();

        output.Body = "Page not found.";

        return output;

    }

}