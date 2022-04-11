using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            for (int num = n; num <= m; num++)
            {
                bool isPrime = true;
                int divider = 2;
                int maxDivider = (int)Math.Sqrt(num);

                while (divider <= maxDivider)
                {
                    if (num % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    divider++;
                }
                if (isPrime)
                {
                    Console.Write(" " + num);
                }
            }

        }
    }
}
