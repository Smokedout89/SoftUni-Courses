using System;

namespace P05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentNum = i;
                int currSum = 0;

                while (currentNum != 0)
                {
                    currSum += currentNum % 10;
                    currentNum = currentNum / 10;
                }

                bool isSpecial = currSum == 5 || currSum == 7 || currSum == 11;

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
