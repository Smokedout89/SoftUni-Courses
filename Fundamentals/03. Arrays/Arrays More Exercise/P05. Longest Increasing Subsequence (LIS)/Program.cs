using System;
using System.Linq;
using System.Collections.Generic;

namespace P05._Longest_Increasing_Subsequence__LIS_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] solutions = new int[numbers.Length];
            int[] previous = new int[numbers.Length];

            int maxSolution = 0;
            int maxSolutionIndex = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                int solution = 1;
                int previousIndex = -1;
                int currentNumber = numbers[current];

                for (int solutionIndex = 0; solutionIndex < current; solutionIndex++)
                {
                    int previousNumber = numbers[solutionIndex];
                    int previousSolution = solutions[solutionIndex];

                    if (currentNumber > previousNumber && solution <= previousSolution)
                    {
                        solution = previousSolution + 1;
                        previousIndex = solutionIndex;
                    }
                }

                solutions[current] = solution;
                previous[current] = previousIndex;

                if (solution > maxSolution)
                {
                    maxSolution = solution;
                    maxSolutionIndex = current;
                }
            }

            int index = maxSolutionIndex;
            List<int> result = new List<int>();

            while (index != -1)
            {
                int currentNumbers = numbers[index];
                result.Add(currentNumbers);
                index = previous[index];
            }

            result.Reverse();

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
