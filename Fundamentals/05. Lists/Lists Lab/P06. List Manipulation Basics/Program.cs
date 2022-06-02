using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] token = command.Split(' ');
                string manipulation = token[0];

                if (manipulation == "Add")
                {
                    int numToAdd = int.Parse(token[1]);
                    numbers.Add(numToAdd);
                }
                else if (manipulation == "Remove")
                {
                    int numToRemove = int.Parse(token[1]);
                    numbers.Remove(numToRemove);
                }
                else if (manipulation == "RemoveAt")
                {
                    int indexToRemove = int.Parse(token[1]);
                    numbers.RemoveAt(indexToRemove);
                }
                else if (manipulation == "Insert")
                {
                    int numToAdd = int.Parse(token[1]);
                    int indexToAdd = int.Parse(token[2]);
                    numbers.Insert(indexToAdd, numToAdd);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
