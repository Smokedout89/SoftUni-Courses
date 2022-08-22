using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> colorType = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                List<string> typeOfCloth = input[1].Split(',').ToList();

                if (!colorType.ContainsKey(color))
                {
                    colorType.Add(color, new Dictionary<string, int>());
                }

                foreach (var type in typeOfCloth)
                {
                    if (!colorType[color].ContainsKey(type))
                    {
                        colorType[color].Add(type, 0);
                    }

                    colorType[color][type]++;
                }
            }

            string[] itemToFind = Console.ReadLine().Split();
            string colorToFind = itemToFind[0];
            string typeToFind = itemToFind[1];

            foreach (var kvp in colorType)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var typeCloth in kvp.Value)
                {
                    if (kvp.Key == colorToFind && typeCloth.Key == typeToFind)
                    {
                        Console.WriteLine($"* {typeCloth.Key} - {typeCloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {typeCloth.Key} - {typeCloth.Value}");
                    }
                }
            }
        }
    }
}
