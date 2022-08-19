using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> table = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();

                foreach (var element in elements)
                {
                    table.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', table.OrderBy(e => e)));
        }
    }
}
