using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ResponseParser
{

    public static string WriteResponse(Response data)
    {

        StringBuilder output = new StringBuilder($"{data.OmtpVersion} {data.ResponseCode} {data.ResponseText}\n");

        foreach (KeyValuePair<string, string> kvp in data.Headers)
        {

            output.Append($"{kvp.Key}: {kvp.Value}");

        }

        output.Append('\n');
        output.Append(data.Body);

        return output.ToString();

    }

}