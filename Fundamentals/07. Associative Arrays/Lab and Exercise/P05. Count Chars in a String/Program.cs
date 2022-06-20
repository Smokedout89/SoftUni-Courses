using System;
using System.Collections.Generic;

namespace P05._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Join(string.Empty, Console.ReadLine().Split());

            Dictionary<char, int> countChars = new Dictionary<char, int>();

            foreach (char letter in text)
            {
                if (countChars.ContainsKey(letter))
                {
                    countChars[letter]++;
                }
                else
                {
                    countChars.Add(letter, 1);
                }
            }

            foreach (var character in countChars)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
