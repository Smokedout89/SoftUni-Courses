using System;

namespace P03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfNumbers = decimal.Parse(Console.ReadLine());
            var sum = 0m;

            for (int i = 0; i < numberOfNumbers; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}
