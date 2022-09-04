using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            Action<int[]> add = number =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    number[i]++;
                }
            };

            Action<int[]> subtract = number =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    number[i]--;
                }
            };

            Action<int[]> multiply = number =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    number[i] *= 2;
                }
            };

            Action<int[]> print = nums => Console.WriteLine(string.Join(' ', nums));

            while (command != "end")
            {
                if (command == "add")
                {
                    add(numbers);
                }
                else if (command == "multiply")
                {
                    multiply(numbers);
                }
                else if (command == "subtract")
                {
                    subtract(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
