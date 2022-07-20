using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(@|#)(?<first>[a-zA-Z]{3,})\1\1(?<second>[a-zA-Z]{3,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);
            List<string[]> mirrorWords = new List<string[]>();

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["first"].Value;
                string secondWord = match.Groups["second"].Value;
                string reversedSecondWord = string.Join("", secondWord.Reverse());

                if (firstWord == reversedSecondWord)
                {
                    mirrorWords.Add(new string[] { firstWord, secondWord });
                }
            }
            
            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                string[] printing = mirrorWords.Select(word => $"{word[0]} <=> {word[1]}").ToArray();

                Console.WriteLine("The mirror words are:");
                Console.Write(string.Join(", ", printing));
            }
        }
    }
}
