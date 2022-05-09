using System;

namespace P02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[i] = number;
            }

            Array.Reverse(numbers);

            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
