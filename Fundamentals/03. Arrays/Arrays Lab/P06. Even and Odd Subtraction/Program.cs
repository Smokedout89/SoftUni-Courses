using System;
using System.Linq;

namespace P06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int oddSum = 0;
            int evenSum = 0;

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    evenSum += item;
                }
                else
                {
                    oddSum += item;
                }
            }

            int difference = (evenSum - oddSum);
            Console.WriteLine(difference);
        }
    }
}
