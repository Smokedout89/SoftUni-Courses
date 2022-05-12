using System;
using System.Linq;

namespace P06._Equal_Sums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isEqual = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += numbers[j];
                }

                int rightSum = 0;

                for (int k = numbers.Length - 1; k > i; k--)
                {
                    rightSum += numbers[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isEqual = true;
                }
            }

            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
