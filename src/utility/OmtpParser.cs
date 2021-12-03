using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OmtpParser
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

            }

        }

        // Set Data
        output.RequestType = RequestType.ToString();
        output.RequestURI = RequestURI.ToString();
        output.OmtpVersion = OmtpVersion.ToString();

        // Set Headers
        output.headers = Enumerable.Range(0, values.Count).ToDictionary(i => headers[i].ToString(), i => values[i].ToString());

        // Return the Object
        return output;

    }

}