using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            int n = int.Parse(Console.ReadLine());

            Func<int, int, bool> divideCheck = (x, y) => x % y == 0;

            List<int> result = numbers.Where(x => !divideCheck(x, n)).ToList();

            Console.WriteLine(string.Join(' ', result));

        }
    }
}
