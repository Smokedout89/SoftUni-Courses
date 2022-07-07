using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P05._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"[A-Za-z]+";
            string numbersPattern = @"(?<numbers>[0-9])";

            //List<string> participants = Console.ReadLine().Split(", ").ToList();

            //foreach (string participant in participants)
            //{
            //    if (!ranking.ContainsKey(participant))
            //    {
            //        ranking.Add(participant, 0);
            //    }
            //}

            Dictionary<string, int> ranking = new Dictionary<string, int>();

            foreach (var name in Console.ReadLine().Split(", "))
            {
                ranking.Add(name, 0);
            }

            string command;

            while ((command = Console.ReadLine()) != "end of race")
            {
                MatchCollection matches = Regex.Matches(command, namePattern);
                StringBuilder sb = new StringBuilder();

                foreach (Match letter in matches)
                {
                    sb.Append(letter);
                }

                string name = sb.ToString();

                if (ranking.ContainsKey(name))
                {
                    MatchCollection kmRun = Regex.Matches(command, numbersPattern);

                    foreach (Match currKm in kmRun)
                    {
                        int curr = int.Parse(currKm.Groups["numbers"].Value);
                        ranking[name] += curr;
                    }
                }
            }

            Dictionary<string, int> winners = ranking.OrderByDescending(km => km.Value)
                .Take(3)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"1st place: {winners.Keys.First()}");
            winners.Remove(winners.Keys.First());
            Console.WriteLine($"2nd place: {winners.Keys.First()}");
            winners.Remove(winners.Keys.First());
            Console.WriteLine($"3rd place: {winners.Keys.First()}");
        }
    }
}
