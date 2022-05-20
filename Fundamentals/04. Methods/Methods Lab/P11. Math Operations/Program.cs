using System;

namespace P11._Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int numberTwo = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(numberOne, @operator, numberTwo));
        }

        static double Calculate(int num1, string input, int num2)
        {
            double result = 0;

            switch (input)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = num1 / num2; break;
            }

            return result;
        }
    }
}
