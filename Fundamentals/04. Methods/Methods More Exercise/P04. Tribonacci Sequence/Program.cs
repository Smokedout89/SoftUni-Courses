using System;

namespace P04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTribonacci(num);
        }

        static void PrintTribonacci(int num)
        {
            int a = 0;
            int b = 0;
            int c = 1;
            int d = a + b + c;

            Console.Write($"1 ");

            for (int i = 1; i < num; i++)
            {
                Console.Write($"{d} ");
                a = b;
                b = c;
                c = d;
                d = a + b + c;
            }
        }
    }
}
