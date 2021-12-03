using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ResponseParser
{

    public static Response ParseResponse(string data, ref int currentState)
    {

        int state = currentState;
        Response output = new Response();

        StringBuilder OmtpVersion = new StringBuilder();
        StringBuilder ResponseCode = new StringBuilder();
        StringBuilder ResponseText = new StringBuilder();

        List<StringBuilder> headers = new List<StringBuilder>();
        List<StringBuilder> values = new List<StringBuilder>();

        StringBuilder body = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {

            char currentByte = data[i];

            switch (state)
            {

                case 0:

                    if (currentByte == ' ')
                    {

                        state = 1;
                        break;

                    }

                    OmtpVersion.Append(currentByte);

                    break;
                case 1:

                    if (currentByte == ' ')
                    {

                        state = 2;
                        break;

                    }

                    ResponseCode.Append(currentByte);

                    break;
                case 2:

                    if (currentByte == '\n')
                    {

                        state = 3;
                        headers.Add(new StringBuilder());
                        break;

                    }

                    ResponseText.Append(currentByte);

                    break;
                case 3:

                    if (currentByte == '\n')
                    {

                        state = 5;
                        break;

                    }

                    if (currentByte == ':')
                    {

                        state = 4;
                        values.Add(new StringBuilder());
                        break;

                    }

                    headers[headers.Count - 1].Append(currentByte);

                    break;
                case 4:

                    if (currentByte == '\n')
                    {

                        state = 3;
                        headers.Add(new StringBuilder());
                        break;

                    }

                    values[values.Count - 1].Append(currentByte);

                    break;
                case 5:

                    body.Append(currentByte);

                    break;

            }

        }

        // Set Data
        output.OmtpVersion = OmtpVersion.ToString();
        output.ResponseText = ResponseText.ToString();
        output.ResponseCode = ResponseCodeToInt(ResponseCode.ToString());

        // Set Headers 
        // TODO: Make this more performant
        output.Headers = Enumerable.Range(0, values.Count).ToDictionary(i => headers[i].ToString(), i => values[i].ToString());

        // Set Body
        output.Body = body.ToString();

        // Return the Object
        return output;

    }

    public static int ResponseCodeToInt(string responseCode)
    {

        // Check that it is three characters long
        if (responseCode.Length != 3) return -1;

        // Find the Three Characters
        char firstChar = responseCode[0];
        char secondChar = responseCode[1];
        char thirdChar = responseCode[2];

        // Get Their Actual Value
        int firstAmount = firstChar - 48;
        int secondAmount = secondChar - 48;
        int thirdAmount = thirdChar - 48;

        // Make Sure They're in Range
        if (firstAmount > 9 || firstAmount < 0) return -1;
        if (secondAmount > 9 || secondAmount < 0) return -1;
        if (thirdAmount > 9 || thirdAmount < 0) return -1;

        // Return the Numeric Version
        return (firstAmount * 100) + (secondAmount * 10) + (thirdAmount);

    }

    public static string WriteResponse(Response data)
    {

        StringBuilder output = new StringBuilder($"{data.OmtpVersion} {data.ResponseCode} {data.ResponseText}\n");

        foreach (KeyValuePair<string, string> kvp in data.Headers)
        {

            output.Append($"{kvp.Key}: {kvp.Value}\n");

        }

        output.Append('\n');
        output.Append(data.Body);

        return output.ToString();

    }

    public int PerformSpeedTest(int testCount)
    {

        // Speed Test
        string input = "OMTP/0.9 200 OK\ntest: testing\nsecond: test again\n\nthis is a body";

        int total = 0;
        for (int n = 0; n < testCount; n++)
        {

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            for (int i = 0; i < 1000000; i++)
            {

                int state = 0;
                ParseResponse(input, ref state);

            }

            watch.Stop();

            total += (int)watch.ElapsedMilliseconds;

        }

        return total / testCount;

    }

}