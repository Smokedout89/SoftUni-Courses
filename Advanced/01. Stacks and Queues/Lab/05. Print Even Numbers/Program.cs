using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //Queue<int> queue = new Queue<int>(numbers.Where(n => n % 2 == 0).ToArray());
            //Console.WriteLine(string.Join(", ", queue));

            Queue<int> queue = new Queue<int>();

            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    queue.Enqueue(num);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
