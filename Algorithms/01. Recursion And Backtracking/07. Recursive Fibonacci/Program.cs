namespace _07.Recursive_Fibonacci
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private readonly static Dictionary<int, long> memo = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FibonacciWithMemo(n + 1));
        }

        private static long FibonacciWithMemo(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            else
            {
                memo.Add(n, FibonacciWithMemo(n - 1) + FibonacciWithMemo(n - 2));
                return memo[n];
            }
        }
    }
}
