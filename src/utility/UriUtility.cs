using System;
using System.Text;

public class UriUtility
{

    public static string encodeUri(string input)
    {

        StringBuilder output = new StringBuilder("");

        for (int i = 0; i < input.Length; i++)
        {

            char inputChar = input[i];

            // Check if the Character is a Number
            if (inputChar > 47 && inputChar < 58)
            {

                output.Append(inputChar);
                continue;

            }

            // Check if the Character is a Lowercase Letter
            if (inputChar > 96 && inputChar < 123)
            {

                output.Append(inputChar);
                continue;

            }

            // Check if the Character is an Uppercase Letter
            if (inputChar > 96 && inputChar < 123)
            {

                output.Append(inputChar);
                continue;

            }

        }

        return output.ToString();

    }

    public static string encodeChar(char input)
    {

        int firstHexCharacter = (input >> 4) & 0x0F;
        int secondHexCharacter = (input >> 0) & 0x0F;

        char firstHexOutput;
        char secondHexOutput;

        switch (firstHexCharacter)
        {
            case 0: firstHexOutput = '0'; break;
            case 1: firstHexOutput = '1'; break;
            case 2: firstHexOutput = '2'; break;
            case 3: firstHexOutput = '3'; break;
            case 4: firstHexOutput = '4'; break;
            case 5: firstHexOutput = '5'; break;
            case 6: firstHexOutput = '6'; break;
            case 7: firstHexOutput = '7'; break;
            case 8: firstHexOutput = '8'; break;
            case 9: firstHexOutput = '9'; break;
            case 10: firstHexOutput = 'A'; break;
            case 11: firstHexOutput = 'B'; break;
            case 12: firstHexOutput = 'C'; break;
            case 13: firstHexOutput = 'D'; break;
            case 14: firstHexOutput = 'E'; break;
            case 15: firstHexOutput = 'F'; break;
            default: firstHexOutput = '0'; break;
        }

        switch (secondHexCharacter)
        {
            case 0: secondHexOutput = '0'; break;
            case 1: secondHexOutput = '1'; break;
            case 2: secondHexOutput = '2'; break;
            case 3: secondHexOutput = '3'; break;
            case 4: secondHexOutput = '4'; break;
            case 5: secondHexOutput = '5'; break;
            case 6: secondHexOutput = '6'; break;
            case 7: secondHexOutput = '7'; break;
            case 8: secondHexOutput = '8'; break;
            case 9: secondHexOutput = '9'; break;
            case 10: secondHexOutput = 'A'; break;
            case 11: secondHexOutput = 'B'; break;
            case 12: secondHexOutput = 'C'; break;
            case 13: secondHexOutput = 'D'; break;
            case 14: secondHexOutput = 'E'; break;
            case 15: secondHexOutput = 'F'; break;
            default: secondHexOutput = '0'; break;
        }

        return $"%{firstHexOutput}{secondHexOutput}";

    }

}