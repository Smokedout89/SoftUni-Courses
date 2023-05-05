namespace _01.Permutations_without_Repetitions
{
    using System;

    internal class Program
    {
        private static string[] elements;

        //private static string[] permutations;
        //private static bool[] used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            //permutations = new string[elements.Length];
            //used = new bool[elements.Length];

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

            for (int i = idx + 1; i < elements.Length; i++)
            {
                Swap(idx, i);
                GeneratePermutation(idx + 1);
                Swap(idx, i);
            }

            //if (idx >= permutations.Length)
            //{
            //    Console.WriteLine(string.Join(" ", permutations));
            //    return;
            //}

            //for (int i = 0; i < elements.Length; i++)
            //{
            //    if (!used[i])
            //    {
            //        used[i] = true;
            //        permutations[idx] = elements[i];

            //        GeneratePermutation(idx + 1);

            //        used[i] = false;
            //    }

            //}
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
