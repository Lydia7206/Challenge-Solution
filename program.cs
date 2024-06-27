using System;
using System.Text.RegularExpressions;

class DateConverter
{
    public static string ReverseDateFormat(string input)
    {
        string pattern = @"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$";
        string replacement = "${year}-${mon}-${day}";

        try
        {
            Regex regex = new Regex(pattern, RegexOptions.None, TimeSpan.FromSeconds(1));
            Match match = regex.Match(input);

            if (match.Success)
            {
                return regex.Replace(input, replacement);
            }
            else
            {
                return "Invalid date format.";
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return "Regex operation timed out. Please try again.";
        }
    }

    static void Main()
    {
        string userInput;
        do
        {
            Console.Write("Enter a date in the format mm/dd/yyyy: ");
            userInput = Console.ReadLine();

            if (DateTime.TryParse(userInput, out _))
            {
                string convertedDate = ReverseDateFormat(userInput);
                Console.WriteLine($"Converted date: {convertedDate}");
            }
            else
            {
                Console.WriteLine("Invalid date. Please enter a valid date.");
            }
        } while (true);
    }
}
