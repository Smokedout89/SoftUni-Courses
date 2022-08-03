using System;
using System.Text;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());

           StringBuilder sb = new StringBuilder();
           Stack<string> stack = new Stack<string>();

           for (int i = 0; i < n; i++)
           {
               string cmd = Console.ReadLine();

               if (cmd.StartsWith("1"))
               {
                   stack.Push(sb.ToString());

                   string toAppend = cmd.Split()[1];
                   sb.Append(toAppend);
               }
               else if (cmd.StartsWith("2"))
               {
                   stack.Push(sb.ToString());

                   int count = int.Parse(cmd.Split()[1]);
                   sb.Remove(sb.Length - count, count);
               }
               else if (cmd.StartsWith("3"))
               {
                    int index = int.Parse(cmd.Split()[1]);
                    Console.WriteLine(sb[index - 1]);
               }
               else if (cmd.StartsWith("4"))
               {
                   sb = new StringBuilder(stack.Pop());
               }
           }
        }
    }
}
