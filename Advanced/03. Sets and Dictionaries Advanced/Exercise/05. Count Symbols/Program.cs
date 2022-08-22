using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> count = new Dictionary<char, int>();

            foreach (char ch in input)
            {
                if (!count.ContainsKey(ch))
                {
                    count.Add(ch, 0);
                }

                count[ch]++;
            }

            foreach (var kvp in count.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
