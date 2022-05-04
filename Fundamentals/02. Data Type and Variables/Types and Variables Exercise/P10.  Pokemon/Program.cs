using System;

namespace P10.__Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int startingN = n;
            int pokesCount = 0;

            while (n >= m)
            {
                n -= m;
                pokesCount++;

                if (n == startingN * 0.5 && y != 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(pokesCount);
        }
    }
}
