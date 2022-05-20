using System;

namespace P10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);

            Console.WriteLine(GetMultipleOfEvenAndOdds(evenSum, oddSum));

        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int currDigit = number % 10;

                if (currDigit % 2 == 0)
                {
                    sum += currDigit;
                }

                number /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int currDig = number % 10;

                if (currDig % 2 != 0)
                {
                    sum += currDig;
                }

                number /= 10;
            }

            return sum;
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
