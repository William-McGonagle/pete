using System;
using System.Collections.Generic;
using System.Linq;

public class OmtpParser
{

    public static Request ParseRequest(string data, ref int currentState)
    {

        int state = currentState;
        Request output = new Request();

        List<string> headers = new List<string>();
        List<string> values = new List<string>();

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

                    output.RequestType += currentByte;

                    break;
                case 1:

                    if (currentByte == ' ')
                    {

                        state = 2;
                        break;

                    }

                    output.RequestURI += currentByte;

                    break;
                case 2:

                    if (currentByte == '\n')
                    {

                        state = 3;
                        headers.Add("");
                        break;

                    }

                    output.OmtpVersion += currentByte;

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
                        values.Add("");
                        break;

                    }

                    Console.Write(currentByte);
                    headers[headers.Count - 1] += currentByte;

                    break;
                case 4:

                    if (currentByte == '\n')
                    {

                        state = 3;
                        headers.Add("");
                        break;

                    }

                    Console.Write(currentByte);
                    values[values.Count - 1] += currentByte;

                    break;

            }

        }

        // Set Headers
        output.headers = Enumerable.Range(0, values.Count).ToDictionary(i => headers[i], i => values[i]);

        // Return the Object
        return output;

    }

}