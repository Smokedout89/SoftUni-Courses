using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9___Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            double averageNumber = numbers.Sum() / (double)numbers.Count;
            List<int> greaterNums = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > averageNumber)
                {
                    greaterNums.Add(numbers[i]);
                }
            }

            greaterNums.Sort();

            if (greaterNums.Count > 5)
            {
                int numsToRemove = greaterNums.Count - 5;
                for (int i = 0; i < numsToRemove; i++)
                {
                    greaterNums.RemoveAt(0);
                }
            }

            greaterNums.Reverse();

            if (greaterNums.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(' ', greaterNums));
            }
        }
    }
}
