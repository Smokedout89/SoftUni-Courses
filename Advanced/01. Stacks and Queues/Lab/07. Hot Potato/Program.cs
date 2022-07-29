using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int number = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(input);

            while (names.Count > 1)
            {
                for (int i = 1; i < number; i++)
                {
                    names.Enqueue(names.Dequeue());
                }

                Console.WriteLine($"Removed {names.Dequeue()}");
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
