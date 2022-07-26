using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack <int> stack = new Stack<int>(numbers);

            string input = Console.ReadLine().ToUpper();

            while (input != "END")
            {
                string[] cmdArgs = input.Split();
                string cmd = cmdArgs[0];

                if (cmd == "ADD")
                {
                    int firstN = int.Parse(cmdArgs[1]);
                    int secondN = int.Parse(cmdArgs[2]);
                    stack.Push(firstN);
                    stack.Push(secondN);
                }
                else if (cmd == "REMOVE")
                {
                    int numsToRemove = int.Parse(cmdArgs[1]);

                    if (stack.Count > numsToRemove)
                    {
                        for (int i = 0; i < numsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        input = Console.ReadLine().ToUpper();
                        continue;
                    }
                }

                input = Console.ReadLine().ToUpper();
            }

            int sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
