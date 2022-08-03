using System;
using System.Collections.Generic;

namespace _08._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>(input);
            bool isMatching = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    stack.Push(input[i]);
                    continue;
                }

                if (stack.Count == 0)
                {
                    isMatching = false;
                    break;
                }

                if (input[i] == ')' && stack.Peek() == '('
                    || input[i] == ']' && stack.Peek() == '['
                    || input[i] == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else
                {
                    isMatching = false;
                    break;
                }
            }

            if (isMatching)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
