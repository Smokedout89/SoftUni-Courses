using System;

namespace P10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                if (DigitsDivisability(i) && HasOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }

        }
        static bool DigitsDivisability(int number)
        {
            int sumOfDigits = 0;

            while (number != 0)
            {
                int currDigit = number % 10;
                sumOfDigits += currDigit;
                number /= 10;
            }

            if (sumOfDigits % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool HasOddDigit(int number)
        {
            while (number != 0)
            {
                int currDigit = number % 10;

                if (currDigit % 2 == 1)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
