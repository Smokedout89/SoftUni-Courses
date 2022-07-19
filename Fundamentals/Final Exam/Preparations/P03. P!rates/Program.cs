using System;
using System.Collections.Generic;

namespace _03._P_rates
{
    class CityInfo
    {
        public CityInfo(int population, int gold)
        {
            this.Population = population;
            this.Gold = gold;
        }

        public int Population { get; set; }

        public int  Gold { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string commandOne = Console.ReadLine();
            Dictionary<string, CityInfo> cities = new Dictionary<string, CityInfo>();

            while (commandOne != "Sail")
            {
                string[] cmdArgs = commandOne.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = cmdArgs[0];
                int population = int.Parse(cmdArgs[1]);
                int gold = int.Parse(cmdArgs[2]);

                if (!cities.ContainsKey(cityName))
                {
                   cities.Add(cityName, new CityInfo(population, gold));
                }
                else
                {
                    cities[cityName].Population += population;
                    cities[cityName].Gold += gold;
                }

                commandOne = Console.ReadLine();
            }

            string commandTwo = Console.ReadLine();

            while (commandTwo != "End")
            {
                string[] cmdArgs = commandTwo.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                string cityName = cmdArgs[1];
                if (cmdType == "Plunder")
                {
                    int population = int.Parse(cmdArgs[2]);
                    int gold = int.Parse(cmdArgs[3]);

                    cities[cityName].Population -= population;
                    cities[cityName].Gold -= gold;

                    Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {population} citizens killed.");

                    if (cities[cityName].Population <= 0 || cities[cityName].Gold <= 0)
                    {
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                        cities.Remove(cityName);
                    }
                }
                else if (cmdType == "Prosper")
                {
                    int gold = int.Parse(cmdArgs[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        commandTwo = Console.ReadLine();
                        continue;
                    }

                    cities[cityName].Gold += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {cities[cityName].Gold} gold.");
                }

                commandTwo = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var keyValuePair in cities)
                {
                    Console.WriteLine($"{keyValuePair.Key} -> Population: {keyValuePair.Value.Population} citizens, Gold: {keyValuePair.Value.Gold} kg");
                }
            }
        }
    }
}
