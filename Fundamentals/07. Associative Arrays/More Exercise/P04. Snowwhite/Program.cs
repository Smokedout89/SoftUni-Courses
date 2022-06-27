using System;
using System.Linq;
using System.Collections.Generic;

namespace P04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string inputLine = Console.ReadLine();

            while (inputLine != "Once upon a time")
            {
                string[] inputArr = inputLine.Split(" <:> ");
                string dwarfName = inputArr[0];
                string hatColour = inputArr[1];
                int physics = int.Parse(inputArr[2]);

                string key = $"({hatColour}) {dwarfName}";

                if (!dwarfs.ContainsKey(key))
                {
                    dwarfs.Add(key, 0);
                }

                if (dwarfs[key] < physics)
                {
                    dwarfs[key] = physics;
                }

                inputLine = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(kvp => kvp.Value)
                         .ThenByDescending(c => dwarfs.Where(kvp => kvp.Key.Split(")")[0] == c.Key.Split(")")[0]).Count()))
            {
                Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");
            }
        }
    }
}
