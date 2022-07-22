using System;
using System.Text.RegularExpressions;

namespace _11._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(\||#)(?<name>[A-Za-z\s?]+)(\1)(?<date>\d{2}\/\d{2}\/\d{2})(\1)(?<calories>\d{1,5})(\1)");

            MatchCollection matches = regex.Matches(input);
            int totalCal = 0;

            foreach (Match match in matches)
            {
                int calories = int.Parse(match.Groups["calories"].Value);
                totalCal += calories;
            }

            int days = totalCal / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
