using System.Collections.Generic;

public class BasicResponse
{

    public const string OMTP_VERSION = "OMTP/0.9";

    /// <summary>
    /// Returns a "100 Continue" Response.
    /// </summary>
    /// <returns>A "100 Continue" Response.</returns>
    public static Response Continue()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 100;
        output.ResponseText = "Continue";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "101 Switching Protocols" Response.
    /// </summary>
    /// <returns>A "101 Switching Protocols" Response.</returns>
    public static Response SwitchingProtocols()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 101;
        output.ResponseText = "Switching Protocols";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "200 OK" Response.
    /// </summary>
    /// <returns>A "200 OK" Response.</returns>
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

    /// <summary>
    /// Returns a "201 Created" Response.
    /// </summary>
    /// <returns>A "201 Created" Response.</returns>
    public static Response Created()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 201;
        output.ResponseText = "Created";

        output.Headers = new Dictionary<string, string>();

        output.Body = "Created";

        return output;

    }

    /// <summary>
    /// Returns a "202 Accepted" Response.
    /// </summary>
    /// <returns>A "202 Accepted" Response.</returns>
    public static Response Accepted()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 202;
        output.ResponseText = "Accepted";

        output.Headers = new Dictionary<string, string>();

        output.Body = "Accepted";

        return output;

    }

    /// <summary>
    /// Returns a "204 No Content" Response.
    /// </summary>
    /// <returns>A "204 No Content" Response.</returns>
    public static Response NoContent()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 204;
        output.ResponseText = "No Content";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "205 Reset Content" Response.
    /// </summary>
    /// <returns>A "205 Reset Content" Response.</returns>
    public static Response ResetContent()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 205;
        output.ResponseText = "Reset Content";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "206 Partial Content" Response.
    /// </summary>
    /// <returns>A "206 Partial Content" Response.</returns>
    public static Response PartialContent()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 206;
        output.ResponseText = "Partial Content";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "300 Multiple Choice" Response.
    /// </summary>
    /// <returns>A "300 Multiple Choice" Response.</returns>
    public static Response MutlipleChoice()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 300;
        output.ResponseText = "Multiple Choice";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "301 Moved Permanently" Response.
    /// </summary>
    /// <returns>A "301 Moved Permanently" Response.</returns>
    public static Response MovedPermanently()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 301;
        output.ResponseText = "Moved Permanently";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "302 Found" Response.
    /// </summary>
    /// <returns>A "302 Found" Response.</returns>
    public static Response Found()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 302;
        output.ResponseText = "Found";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "303 See Other" Response.
    /// </summary>
    /// <returns>A "303 See Other" Response.</returns>
    public static Response SeeOther()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 303;
        output.ResponseText = "See Other";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "304 Not Modified" Response.
    /// </summary>
    /// <returns>A "304 Not Modified" Response.</returns>
    public static Response NotModified()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 304;
        output.ResponseText = "Not Modified";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "307 Temporary Redirect" Response.
    /// </summary>
    /// <returns>A "307 Temporary Redirect" Response.</returns>
    public static Response TemporaryRedirect()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 307;
        output.ResponseText = "Temporary Redirect";

        output.Headers = new Dictionary<string, string>();

        output.Body = "";

        return output;

    }

    /// <summary>
    /// Returns a "308 Permanent Redirect" Response.
    /// </summary>
    /// <returns>A "308 Permanent Redirect" Response.</returns>
    public static Response PermanentRedirect()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 308;
        output.ResponseText = "Permanent Redirect";

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

        output.Body = "Not Found.";

        return output;

    }

    public static Response InternalError()
    {

        Response output = new Response();

        output.OmtpVersion = OMTP_VERSION;
        output.ResponseCode = 500;
        output.ResponseText = "Internal Server Error";

        output.Headers = new Dictionary<string, string>();

        output.Body = "Internal Server Error.";

        return output;

    }

}