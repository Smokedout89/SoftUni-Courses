using System;
using System.Numerics;

namespace P08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double firstFact = Factorial(firstNum);
            double secondFact = Factorial(secondNum);

            double result = firstFact / secondFact;

            Console.WriteLine($"{result:f2}");
        }

        static double Factorial(int number)
        {
            double result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

    }
}
