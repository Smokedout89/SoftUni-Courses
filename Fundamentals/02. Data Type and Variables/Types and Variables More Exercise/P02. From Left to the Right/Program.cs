using System;
using System.Linq;

namespace P02._From_Left_to_the_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long leftNum = (input[0]);
                long rightNum = (input[1]);

                long sum = 0;
                long currDigit = 0;

                if (leftNum > rightNum)
                {
                    leftNum = Math.Abs(leftNum);
                    while (leftNum != 0)
                    {
                        currDigit = leftNum % 10;
                        sum += currDigit;
                        leftNum /= 10;
                    }
                }
                else
                {
                    rightNum = Math.Abs(rightNum);
                    while (rightNum != 0)
                    {
                        currDigit = rightNum % 10;
                        sum += currDigit;
                        rightNum /= 10;
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}
