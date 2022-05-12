using System;
using System.Linq;

namespace P08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                int currN = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int currSecondN = numbers[j];

                    if (currN + currSecondN == n)
                    {
                        Console.WriteLine($"{currN} {currSecondN}");
                    }
                }
            }
        }
    }
}
