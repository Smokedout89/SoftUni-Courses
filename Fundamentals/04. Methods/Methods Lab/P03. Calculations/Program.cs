using System;

namespace P03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (input)
            {
                case "add": Add(num1, num2); break;
                case "multiply": Multiply(num1, num2); break;
                case "subtract": Subtract(num1, num2); break;
                case "divide": Divide(num1, num2); break;
            }
        }

        static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        static void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        static void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}
