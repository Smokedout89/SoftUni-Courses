using System;
using System.Linq;

namespace P05._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = 0;

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    sum += item;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
