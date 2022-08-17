using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentsData =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');

                string continent = cmdArgs[0];
                string country = cmdArgs[1];
                string city = cmdArgs[2];

                if (!continentsData.ContainsKey(continent))
                {
                    continentsData[continent] = new Dictionary<string, List<string>>();
                }

                if (!continentsData[continent].ContainsKey(country))
                {
                    continentsData[continent][country] = new List<string>();
                }

                continentsData[continent][country].Add(city);
            }

            foreach (var continentCountry in continentsData)
            {
                string continentName = continentCountry.Key;
                Console.WriteLine($"{continentName}:");

                foreach (var countryCity in continentCountry.Value)
                {
                    Console.WriteLine($"{countryCity.Key} -> {string.Join(", ", countryCity.Value)}");

                    //string countryName = countryCity.Key;
                    //List<string> cityName = countryCity.Value;
                    //Console.WriteLine($"{countryName} -> {string.Join(", ", cityName)}");
                }
            }
        }
    }
}
