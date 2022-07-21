using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Plant_Discovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
        }

        public List<double> Rating { get; set; } = new List<double>();

        public string Name { get; set; }

        public int Rarity { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->");
                string plant = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);

                if (!plants.Exists(name => name.Name.Equals(plant)))
                {
                    plants.Add(new Plant(plant, rarity));
                }
                else
                {
                    Plant current = plants.Find(name => name.Name.Equals(plant));
                    current.Rarity = rarity;
                }
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] cmdArgs = input.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                string plantName = cmdArgs[1];

                if (command == "Rate")
                {
                    double rating = double.Parse(cmdArgs[2]);

                    if (plants.Exists(name => name.Name.Equals(plantName)))
                    {
                        Plant currPlant = plants.Find(name => name.Name.Equals(plantName));
                        currPlant.Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Update")
                {
                    int newRarity = int.Parse(cmdArgs[2]);

                    if (plants.Exists(name => name.Name.Equals(plantName)))
                    {
                        Plant currPlant = plants.Find(name => name.Name.Equals(plantName));
                        currPlant.Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Reset")
                {
                    if (plants.Exists(name => name.Name.Equals(plantName)))
                    {
                        Plant currPlant = plants.Find(name => name.Name.Equals(plantName));
                        currPlant.Rating.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant plant in plants)
            {
                if (plant.Rating.Count != 0)
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Rating.Average():f2}");
                }
                else
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {0:f2}");
                }
            }
        }
    }
}
