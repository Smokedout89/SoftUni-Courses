using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            Box<string> box = new Box<string>(list);
            string elementsToCompare = Console.ReadLine();
            int count = box.CountOfGreaterElements(list, elementsToCompare);
            Console.WriteLine(count);
        }
    }
}
