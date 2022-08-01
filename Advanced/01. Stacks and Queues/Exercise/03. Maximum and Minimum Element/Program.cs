using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numOfQueries; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmd = cmdArgs[0];

                if (cmd == "1")
                {
                    int element = int.Parse(cmdArgs[1]);
                    stack.Push(element);
                }
                else if (stack.Any())
                {
                    switch (cmd)
                    {
                        case "2":
                            stack.Pop();
                            break;
                        case "3":
                            Console.WriteLine(stack.Max());
                            break;
                        case "4":
                            Console.WriteLine(stack.Min());
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
