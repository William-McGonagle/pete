using System.Text;

public class HeaderUtility
{

    public static string FormatHeader(string data)
    {

        StringBuilder output = new StringBuilder();
        bool capitalizeNext = true;

        for (int i = 0; i < data.Length; i++)
        {

            int currentChar = data[i];

            if (capitalizeNext)
            {

                if (currentChar > 96 && currentChar < 123)
                    output.Append((char)(currentChar - 32));

                if (currentChar > 64 && currentChar < 91)
                    output.Append((char)currentChar);

                capitalizeNext = false;

            }
            else
            {

                if (currentChar == '-')
                {
                    capitalizeNext = true;
                    output.Append('-');
                }

                if (currentChar == ' ')
                {
                    capitalizeNext = true;
                    output.Append('-');
                }

                if (currentChar > 96 && currentChar < 123)
                    output.Append((char)currentChar);

                if (currentChar > 64 && currentChar < 91)
                    output.Append((char)(currentChar + 32));

                // output.Append((char)currentChar); 

            }

        }

        return output.ToString();

    }

}