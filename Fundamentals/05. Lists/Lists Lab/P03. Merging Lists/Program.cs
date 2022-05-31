using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstArr = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondArr = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            int longerList = Math.Max(firstArr.Count, secondArr.Count);

            for (int i = 0; i < longerList; i++)
            {
                if (i < firstArr.Count)
                {
                    result.Add(firstArr[i]);
                }

                if (i < secondArr.Count)
                {
                    result.Add(secondArr[i]);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
