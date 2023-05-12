namespace _04.Variations_with_Repetition
{
    using System;

    internal class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];

            GenerateVariations(0);
        }

        private static void GenerateVariations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[idx] = elements[i];
                GenerateVariations(idx + 1);
            }
        }
    }
}
