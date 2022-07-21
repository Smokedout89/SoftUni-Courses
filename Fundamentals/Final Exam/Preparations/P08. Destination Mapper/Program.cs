using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\=|\/)([A-Z][A-Za-z]{2,})(\1)";
            int travelPoints = 0;
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> destinations = new List<string>();
            foreach (Match match in matches)
            {
                string currMatch = match.Groups[2].Value;
                destinations.Add(currMatch);
                travelPoints += currMatch.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}   
