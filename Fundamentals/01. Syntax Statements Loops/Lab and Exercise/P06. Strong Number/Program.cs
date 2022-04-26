using System;

namespace P06._Strong_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copyNumber = number;
            int currentNumber = 0;
            int factorialSum = 0;

            while (copyNumber != 0)
            {
                currentNumber = copyNumber % 10;
                copyNumber = copyNumber / 10;

                int factorial = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    factorial *= i;
                }
                factorialSum += factorial;
            }

            if (number == factorialSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
