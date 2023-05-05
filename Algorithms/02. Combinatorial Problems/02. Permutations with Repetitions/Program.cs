namespace _02.Permutations_with_Repetitions
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            GeneratePermutation(0);
        }

        private static void GeneratePermutation(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            GeneratePermutation(idx + 1);

            HashSet<string> used = new HashSet<string> { elements[idx] };

            for (int i = idx + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(idx, i);
                    GeneratePermutation(idx + 1);
                    Swap(idx, i);

                    used.Add(elements[i]);
                }             
            }
        }

        private static void Swap(int first, int second)
        {
            // (elements[first], elements[second]) = (elements[second], elements[first]);

            string temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
