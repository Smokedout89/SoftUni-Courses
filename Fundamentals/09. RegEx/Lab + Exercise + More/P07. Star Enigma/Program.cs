using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P07._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                string decryptedMessage = DecryptMessage(encryptedMessage);
                string pattern =
                    @"\@(?<planet>[A-Za-z]+)+[^\@\-\!\:]*?\:(?<population>[0-9]+)+[^\@\-\!\:]*?\!(?<attackType>[A|D]{1})\![^\@\-\!\:]*?\-\>(?<count>[0-9]+)0";
                Match match = Regex.Match(decryptedMessage, pattern);

                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(n => n))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(n => n))
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        static int DecryptionCount(string encyptedMessage)
        {
            string decryptPattern = @"[star]{1}";
            MatchCollection matches = Regex.Matches(encyptedMessage, decryptPattern, RegexOptions.IgnoreCase);

            return matches.Count;
        }

        static string DecryptMessage(string encryptedMessage)
        {
            int matchesCounted = DecryptionCount(encryptedMessage);

            StringBuilder decryptedMessage = new StringBuilder();

            foreach (char currCh in encryptedMessage)
            {
                char ch = currCh;
                ch -= (char) matchesCounted;
                decryptedMessage.Append(ch);
            }

            return decryptedMessage.ToString();
        }
    }
}
