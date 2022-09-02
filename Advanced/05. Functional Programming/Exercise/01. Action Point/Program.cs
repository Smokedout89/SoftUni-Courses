using System;

namespace _01._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> printNames = allNames => Console.WriteLine(string.Join(Environment.NewLine, allNames));

            printNames(input);
        }
    }
}
