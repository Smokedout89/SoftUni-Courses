using System;
using System.Linq;

namespace P07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = 0;
            bool isIdentical = true;

            for (int i = 0; i < arr1.Length; i++)
            {
                sum += arr2[i];

                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    isIdentical = false;
                    break;
                }

            }

            if (isIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
