using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            Box<string> box = new Box<string>(list);
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(list, indexes[0], indexes[1]);

            Console.WriteLine(box);
        }
    }
}
