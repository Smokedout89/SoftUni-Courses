using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (var wordInfo in input)
            {
                string[] wordDefinition = wordInfo.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string word = wordDefinition[0];
                string definition = wordDefinition[1];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>() { $" -{definition}" });
                }
                else
                {
                    dictionary[word].Add($" -{definition}");
                }
            }

            string[] words = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);

            string finalCmd = Console.ReadLine();

            if (finalCmd == "Test")
            {
                foreach (var word in words)
                {
                    if (dictionary.ContainsKey(word))
                    {
                        Console.WriteLine($"{word}:");

                        foreach (var definition in dictionary[word])
                        {
                            Console.WriteLine(string.Join("\n", definition));
                        }

                        //foreach (var item in dictionary.Where(w => w.Key == word))
                        //{
                        //    Console.WriteLine($"{item.Key}:");
                        //    Console.WriteLine(string.Join("\n", item.Value));
                        //}
                    }
                }
            }
            else if (finalCmd == "Hand Over")
            {
                Console.WriteLine(string.Join(' ', dictionary.Keys));

               // Console.WriteLine(string.Join(' ', dictionary.Select(w => w.Key)));
            }
        }
    }
}
