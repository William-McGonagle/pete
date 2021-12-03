using System.Text;

public class HeaderUtility
{

    public static string FormatHeader(string data)
    {

        StringBuilder output = new StringBuilder();
        bool capitalizeNext = true;

        for (int i = 0; i < data.Length; i++)
        {

            char currentChar = data[i];

            if (capitalizeNext)
            {

                if (currentChar > 96 && currentChar < 123)
                    output.Append(currentChar - 32);

                if (currentChar > 64 && currentChar < 91)
                    output.Append(currentChar);

            }
            else
            {

                if (currentChar == '-')
                    capitalizeNext = true;

                if (currentChar > 96 && currentChar < 123)
                    output.Append(currentChar);

                if (currentChar > 64 && currentChar < 91)
                    output.Append(currentChar + 32);

                output.Append(currentChar);

            }

        }

        return output.ToString();

    }

}