namespace _04.Recursive_Factorial
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorialRecursively(n));
        }

        private static int GetFactorialRecursively(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * GetFactorialRecursively(n - 1);
        }
    }
}
