using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordToLower = word.ToLower();

                if (counts.ContainsKey(wordToLower))
                {
                    counts[wordToLower]++;
                }
                else
                {
                    counts.Add(wordToLower, 1);
                }
            }

            string[] result = counts
                .Where(item => item.Value % 2 != 0)
                .Select(item => item.Key)
                .ToArray();

            Console.WriteLine(string.Join(' ', result));

            //foreach (var count in counts)
            //{
            //    if (count.Value % 2 != 0)
            //    {
            //        Console.Write(count.Key + " ");
            //    }
            //}
        }
    }
}
