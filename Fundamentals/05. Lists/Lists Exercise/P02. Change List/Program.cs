using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] token = command.Split();

                if (token[0] == "Delete")
                {
                    int numToDelete = int.Parse(token[1]);
                    numbers.RemoveAll(x => x == numToDelete);
                }
                else if (token[0] == "Insert")
                {
                    int element = int.Parse(token[1]);
                    int position = int.Parse(token[2]);
                    numbers.Insert(position, element);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
