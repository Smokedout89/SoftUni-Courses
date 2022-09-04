using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isLessOrEqual = (name, length) => name.Length <= length;

            List<string> result = names.Where(x => isLessOrEqual(x, n)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
