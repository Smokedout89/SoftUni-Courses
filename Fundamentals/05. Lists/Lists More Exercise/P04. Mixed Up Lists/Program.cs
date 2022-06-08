using System;
using System.Linq;
using System.Collections.Generic;

namespace P04._Mixed_Up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> combinedList = new List<int>();

            int smallerList = Math.Min(firstList.Count, secondList.Count);
            secondList.Reverse();

            for (int i = 0; i < smallerList; i++)
            {
                combinedList.Add(firstList[i]);
                combinedList.Add(secondList[i]);
            }

            int constraitOne = 0;
            int constraitTwo = 0;

            if (firstList.Count > secondList.Count)
            {
                constraitOne = firstList[firstList.Count - 1];
                constraitTwo = firstList[firstList.Count - 2];
            }
            else
            {
                constraitOne = secondList[secondList.Count-1];
                constraitTwo = secondList[secondList.Count - 2];
            }

            int smallerCons = Math.Min(constraitTwo, constraitOne);
            int biggerCons = Math.Max(constraitOne, constraitTwo);
            List<int> listToPrint = new List<int>();

            for (int i = 0; i < combinedList.Count; i++)
            {
                if (combinedList[i] > smallerCons && combinedList[i] < biggerCons)
                {
                    listToPrint.Add(combinedList[i]);
                }
                else
                {
                    continue;
                }
            }

            listToPrint.Sort();

            Console.WriteLine(string.Join(' ', listToPrint));
        }
    }
}
