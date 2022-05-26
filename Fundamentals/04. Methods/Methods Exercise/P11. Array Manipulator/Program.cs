using System;
using System.Collections.Generic;
using System.Linq;

namespace P11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    inputArray = ExchangedArray(inputArray, int.Parse(command[1]));
                }
                else if (command[0] == "min" || command[0] == "max")
                {
                    FindMinMax(inputArray, command[0], command[1]);
                }
                else if (command[0] == "first" || command[0] == "last")
                {
                    FindNumbers(inputArray, command[0], int.Parse(command[1]), command[2]);
                }
                
                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"[{string.Join(", ", inputArray)}]");

        }

        static int[] ExchangedArray(int[] currentArray, int exchangeIndex)
        {
            if (exchangeIndex < 0 || exchangeIndex >= currentArray.Length)
            {
                Console.WriteLine("Invalid index");
                return currentArray;
            }

            int[] newArray = new int[currentArray.Length];
            int startingIndex = 0;

            for (int i = exchangeIndex + 1; i < currentArray.Length; i++)
            {
                newArray[startingIndex] = currentArray[i];
                startingIndex++;
            }

            for (int i = 0; i <= exchangeIndex; i++)
            {
                newArray[startingIndex] = currentArray[i];
                startingIndex++;
            }

            return newArray;
        }

        static void FindMinMax(int[] currentArray, string minOrMax, string evenOrOdd)
        {
            int index = -1;
            int min = int.MaxValue;
            int max = int.MinValue;

            int resultOddEven = 1;

            if (evenOrOdd == "even") resultOddEven = 0;

            for (int i = 0; i < currentArray.Length; i++)
            {
                if (currentArray[i] % 2 == resultOddEven)
                {
                    if (minOrMax == "min" && min >= currentArray[i])
                    {
                        min = currentArray[i];
                        index = i;
                    }
                    else if (minOrMax == "max" && max <= currentArray[i])
                    {
                        max = currentArray[i];
                        index = i;
                    }
                }
            }

            if (index > -1) Console.WriteLine(index);
            else Console.WriteLine("No matches");
        }

        static void FindNumbers(int[] currentArray, string position, int numbersCount, string evenOrOdd)
        {
            if (numbersCount > currentArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (numbersCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            int resultOddEven = 1;
            if (evenOrOdd == "even") resultOddEven = 0;

            int count = 0;

            List<int> nums = new List<int>();

            if (position == "first")
            {
                foreach (var num in currentArray)
                {
                    if (num % 2 == resultOddEven)
                    {
                        count++;
                        nums.Add(num);
                    }

                    if (count == numbersCount) break;
                }
            }
            else
            {
                for (int i = currentArray.Length - 1 ; i >= 0; i--)
                {
                    if (currentArray[i] % 2 == resultOddEven)
                    {
                        count++;
                        nums.Add(currentArray[i]);
                    }

                    if (count == numbersCount) break;
                }

                nums.Reverse();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

    }
}
