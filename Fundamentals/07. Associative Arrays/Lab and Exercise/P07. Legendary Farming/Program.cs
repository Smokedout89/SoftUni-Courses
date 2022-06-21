using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>()
            {
                {"shards", 0},
                {"motes", 0},
                {"fragments", 0}
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();

            bool isLegendaryFound = false;

            while (!isLegendaryFound)
            {
                string[] items = Console.ReadLine().Split().ToArray();

                for (int i = 0; i < items.Length - 1; i += 2)
                {

                    int currQuantity = int.Parse(items[i]);
                    string material = items[i + 1].ToLower();

                    AddMaterialsOrJunk(materials, junk, currQuantity, material);

                    if (materials["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        materials["shards"] -= 250;
                        isLegendaryFound = true;
                        break;
                    }

                    if (materials["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        materials["fragments"] -= 250;
                        isLegendaryFound = true;
                        break;
                    }

                    if (materials["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        materials["motes"] -= 250;
                        isLegendaryFound = true;
                        break;
                    }
                }
            }

            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junk)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }

        static void AddMaterialsOrJunk(Dictionary<string, int> materials, Dictionary<string, int> junk,
            int currQuantity, string material)

        {
            if (material == "shards" || material == "fragments" || material == "motes")
            {
                materials[material] += currQuantity;
            }
            else
            {
                if (!junk.ContainsKey(material))
                {
                    junk.Add(material, 0);
                }

                junk[material] += currQuantity;
            }
        }
    }
}
