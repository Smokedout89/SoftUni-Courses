using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            Box<int> box = new Box<int>(list);
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(list, indexes[0], indexes[1]);

            Console.WriteLine(box);
        }
    }
}
