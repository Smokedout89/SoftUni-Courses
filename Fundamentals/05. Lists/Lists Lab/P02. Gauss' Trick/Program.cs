using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> newNums = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int currNum = numbers[i] + numbers[numbers.Count - 1 - i];
                newNums.Add(currNum);
            }

            if (numbers.Count % 2 != 0)
            {
                newNums.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(' ', newNums));
        }
    }
}
