using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] token = input.Split();

                if (token[0] == "Add")
                {
                    int numberToAdd = int.Parse(token[1]);
                    numbers.Add(numberToAdd);
                }
                else if (token[0] == "Insert")
                {
                    int numberToAdd = int.Parse(token[1]);
                    int index = int.Parse(token[2]);
                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, numberToAdd);
                    }
                }
                else if (token[0] == "Remove")
                {
                    int indexToRemove = int.Parse(token[1]);
                    if (indexToRemove < 0 || indexToRemove >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(indexToRemove);
                    }
                }
                else if (token[0] == "Shift" && token[1] == "left")
                {
                    int timesToRepeat = int.Parse(token[2]);
                    for (int i = 0; i < timesToRepeat; i++)
                    {
                        int currNum = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(currNum);
                    }

                }
                else if (token[0] == "Shift" && token[1] == "right")
                {
                    int timesToRepeat = int.Parse(token[2]);
                    for (int i = 0; i < timesToRepeat; i++)
                    {
                        int currNum = numbers[numbers.Count - 1];
                        numbers.Insert(0, currNum);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
