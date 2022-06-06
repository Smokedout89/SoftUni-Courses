using System;
using System.Collections.Generic;
using System.Linq;

namespace P09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumOfRemovedItems = 0;

            while (numbers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    index = 0;
                    int numAtIndex = numbers[index];

                    numAtIndex = numbers[index];
                    sumOfRemovedItems += numAtIndex;
                    CatchPokemon(numbers, index, numAtIndex);
                    int numToCopy = numbers[numbers.Count - 1];
                    numbers.Insert(index, numToCopy);
                }
                else if (index >= numbers.Count)
                {
                    index = numbers.Count - 1;
                    int numAtIndex = numbers[index];

                    numAtIndex = numbers[index];
                    sumOfRemovedItems += numAtIndex;
                    CatchPokemon(numbers, index, numAtIndex);
                    int numToCopy = numbers[0];
                    numbers.Insert(index, numToCopy);
                }
                else
                {
                    int numAtIndex = numbers[index];
                    sumOfRemovedItems += numAtIndex;
                    CatchPokemon(numbers, index, numAtIndex);
                }

            }

            Console.WriteLine(sumOfRemovedItems);
        }

        static void CatchPokemon(List<int> nums, int index, int numAtIndex)
        {

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] <= numAtIndex)
                {
                    nums[i] += numAtIndex;
                }
                else
                {
                    nums[i] -= numAtIndex;
                }
            }

            nums.RemoveAt(index);
        }
    }
}
