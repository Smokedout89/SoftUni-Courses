using System.Collections.Generic;
using System.Linq;

namespace _05.School_Teams
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsCombs = new string[3];
            var girlsCombinations = new List<string[]>();
            GenerateCombinations(0, 0, girls, girlsCombs, girlsCombinations);

            var boys = Console.ReadLine().Split(", ");
            var boysCombs = new string[2];
            var boysCombinations = new List<string[]>();
            GenerateCombinations(0, 0, boys, boysCombs, boysCombinations);

            PrintFinalCombinations(girlsCombinations, boysCombinations);
        }

        private static void PrintFinalCombinations(List<string[]> girlsCombinations, List<string[]> boysCombinations)
        {
            foreach (var girlsCombination in girlsCombinations)
            {
                foreach (var boysCombination in boysCombinations)
                {
                    Console.WriteLine($"{string.Join(", ", girlsCombination)}, {string.Join(", ", boysCombination)}");
                }
            }
        }

        private static void GenerateCombinations(int idx, int start, string[] elements, string[] combs, List<string[]> combinations)
        {
            if (idx >= combs.Length)
            {
                combinations.Add(combs.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combs[idx] = elements[i];
                GenerateCombinations(idx + 1, i + 1, elements, combs, combinations);
            }
        }
    }
}
