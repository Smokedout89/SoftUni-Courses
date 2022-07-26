using System;
using System.Collections.Generic;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Array.Reverse(input);
            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                string symbol = stack.Pop();
                int secondNum = int.Parse(stack.Pop());

                switch (symbol)
                {
                    case "+":
                        stack.Push((firstNum + secondNum).ToString());
                        break;
                    case "-":
                        stack.Push((firstNum - secondNum).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
