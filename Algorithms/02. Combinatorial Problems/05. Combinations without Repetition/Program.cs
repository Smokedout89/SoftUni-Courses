namespace _05.Combinations_without_Repetition
{
    using System;

    internal class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            GenerateCombinations(0, 0);
        }

        private static void GenerateCombinations(int idx, int elementStartIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIdx; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                GenerateCombinations(idx + 1, i + 1);
            }
        }
    }
}
