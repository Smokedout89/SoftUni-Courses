using System;

namespace P05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
           int quantity = int.Parse(Console.ReadLine());

           OrderPrice(input, quantity);
        }

        private static void OrderPrice(string name, int num)
        {
            double result = 0;

            switch (name)
            {
                case "coffee": result = num * 1.50; break;
                case "water": result = num * 1.00; break;
                case "snacks": result = num * 2.00; break;
                case "coke": result = num * 1.40; break;
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}
