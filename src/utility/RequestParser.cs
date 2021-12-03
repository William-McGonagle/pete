using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RequestParser
{

    public static Request ParseRequest(string data, ref int currentState)
    {

        int state = currentState;
        Request output = new Request();

        StringBuilder RequestType = new StringBuilder();
        StringBuilder RequestURI = new StringBuilder();
        StringBuilder OmtpVersion = new StringBuilder();

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

                    RequestType.Append(currentByte);

                    break;
                case 1:

                    if (currentByte == ' ')
                    {

                        state = 2;
                        break;

                    }

                    RequestURI.Append(currentByte);

                    break;
                case 2:

                    if (currentByte == '\n')
                    {

                        state = 3;
                        headers.Add(new StringBuilder());
                        break;

                    }

                    OmtpVersion.Append(currentByte);

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
        output.RequestType = RequestType.ToString();
        output.RequestURI = RequestURI.ToString();
        output.OmtpVersion = OmtpVersion.ToString();

        // Set Headers 
        // TODO: Make this more performant
        output.Headers = Enumerable.Range(0, values.Count).ToDictionary(i => headers[i].ToString(), i => values[i].ToString());

        // Set Body
        output.Body = body.ToString();

        // Return the Object
        return output;

    }

    public int PerformSpeedTest(int testCount)
    {

        // Speed Test
        string input = "GET /test OMTP/0.9\ntest: testing\nsecond: test again\n\nthis is a body";

        int total = 0;
        for (int n = 0; n < testCount; n++)
        {

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            for (int i = 0; i < 1000000; i++)
            {

                int state = 0;
                ParseRequest(input, ref state);

            }

            watch.Stop();

            total += (int)watch.ElapsedMilliseconds;

        }

        return total / testCount;

    }

}