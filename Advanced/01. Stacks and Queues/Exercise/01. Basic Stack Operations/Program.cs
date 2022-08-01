using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            int numsToPush = input[0];
            int numsToPop = input[1];
            int elementToLook = input[2];

            for (int i = 0; i < numsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Any())
            {
                if (stack.Contains(elementToLook))
                {
                    Console.WriteLine("true");
                }   
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
