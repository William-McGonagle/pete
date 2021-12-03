using System.Collections.Generic;

public class OmtpParser
{

    public static Request ParseRequest(byte[] data, int currentState)
    {

        int state = currentState;
        Request output = new Request();

        List<string> headers = new List<string>();
        List<string> values = new List<string>();

        for (int i = 0; i < data[i]; i++)
        {

            char currentByte = (char)data[i];

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

                    headers[headers.Count - 1] += currentByte;

                    break;
                case 4:

                    if (currentByte == '\n')
                    {

                        state = 3;
                        headers.Add("");
                        break;

                    }

                    values[values.Count - 1] += currentByte;

                    break;

            }

        }

        // Set Headers


        // Return the Object
        return output;

    }

}