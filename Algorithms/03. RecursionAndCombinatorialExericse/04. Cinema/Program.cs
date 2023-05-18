namespace _04.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] lockedPositions;

        static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStaticPeople.Count];
            lockedPositions = new bool[nonStaticPeople.Count];

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "generate")
                {
                    break;
                }

                string[] inputParts = input.Split(" - ");
                string name = inputParts[0];
                int position = int.Parse(inputParts[1]) - 1;

                people[position] = name;
                lockedPositions[position] = true;

                nonStaticPeople.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= nonStaticPeople.Count)
            {
                PrintPermutation();
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }
        }

        private static void PrintPermutation()
        {
            int nonStaticIdx = 0;

            for (int i = 0; i < people.Length; i++)
            {
                if (!lockedPositions[i])
                {
                    people[i] = nonStaticPeople[nonStaticIdx++];
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}
