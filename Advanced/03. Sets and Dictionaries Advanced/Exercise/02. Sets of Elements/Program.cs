using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> one = new HashSet<int>();
            HashSet<int> two = new HashSet<int>();

            for (int i = 0; i < lenghts[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                one.Add(num);
            }

            for (int i = 0; i < lenghts[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                two.Add(num);
            }

            one.IntersectWith(two);

            Console.WriteLine(string.Join(' ', one));
        }
    }
}
