using System;

namespace P02._Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int divider = -1;

            if (n % 10 == 0)
            {
                divider = 10;
            }
            else if (n % 7 == 0)
            {
                divider = 7;
            }
            else if (n % 6 == 0)
            {
                divider = 6;
            }
            else if (n % 3 == 0)
            {
                divider = 3;
            }
            else if (n % 2 == 0)
            {
                divider = 2;
            }

            if (divider == -1)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {divider}");
            }
        }
    }
}
