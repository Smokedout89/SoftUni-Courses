using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                int currFood = queue.Peek();

                if (foodQuantity - currFood >= 0 )
                {
                    foodQuantity -= currFood;
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
                    break;
                }
            }

            if (!queue.Any())
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
