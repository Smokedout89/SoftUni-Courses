using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int[] numbers = new int[input.Length];
            List<int> result = new List<int>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                numbers = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                foreach (var item in numbers)
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}