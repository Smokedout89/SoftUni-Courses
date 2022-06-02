using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            bool isChanged = false;

            while (command != "end")
            {
                string[] token = command.Split(' ');
                string manipulation = token[0];

                if (manipulation == "Add")
                {
                    int numToAdd = int.Parse(token[1]);
                    numbers.Add(numToAdd);
                    isChanged = true;
                }
                else if (manipulation == "Remove")
                {
                    int numToRemove = int.Parse(token[1]);
                    numbers.Remove(numToRemove);
                    isChanged = true;
                }
                else if (manipulation == "RemoveAt")
                {
                    int indexToRemove = int.Parse(token[1]);
                    numbers.RemoveAt(indexToRemove);
                    isChanged = true;
                }
                else if (manipulation == "Insert")
                {
                    int numToAdd = int.Parse(token[1]);
                    int indexToAdd = int.Parse(token[2]);
                    numbers.Insert(indexToAdd, numToAdd);
                    isChanged = true;
                }
                else if (manipulation == "Contains")
                {
                    int numToContain = int.Parse(token[1]);

                    if (numbers.Contains(numToContain))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (manipulation == "PrintEven")
                {
                    List<int> evenNums = numbers.FindAll(x => x % 2 == 0);
                    Console.WriteLine(string.Join(' ', evenNums));
                }
                else if (manipulation == "PrintOdd")
                {
                    List<int> oddNums = numbers.FindAll(x => x % 2 != 0);
                    Console.WriteLine(string.Join(' ', oddNums));
                }
                else if (manipulation == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (manipulation == "Filter")
                {
                    string condition = token[1];
                    int number = int.Parse(token[2]);
                    List<int> result = FilterNumbers(numbers, condition, number);
                    Console.WriteLine(string.Join(' ', result));
                }

                command = Console.ReadLine();
            }

            if (isChanged) Console.WriteLine(string.Join(' ', numbers));

        }

        static List<int> FilterNumbers(List<int> allNumbers, string condition, int number)
        {

            if (condition == "<")
            {
                List<int> result = allNumbers.FindAll(x => x < number);
                return result;
            }
            else if (condition == ">")
            {
                List<int> result = allNumbers.FindAll(x => x > number);
                return result;
            }
            else if (condition == "<=")
            {
                List<int> result = allNumbers.FindAll(x => x <= number);
                return result;
            }
            else if (condition == ">=")
            {
                List<int> result = allNumbers.FindAll(x => x >= number);
                return result;
            }
            else
            {
                return allNumbers;
            }

        }
    }
}
