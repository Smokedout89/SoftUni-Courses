using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> forceRegister = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] data = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string side = data[0];
                    string user = data[1];

                    if (forceRegister.ContainsKey(side) == false)
                    {
                        forceRegister.Add(side, new List<string>());
                    }
                    if (forceRegister[side].Contains(user) == false && forceRegister.Values.Any(x => x.Contains(user)) == false)
                    {
                        forceRegister[side].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] data = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string user = data[0];
                    string side = data[1];

                    if (forceRegister.Any(x => x.Value.Contains(user)) == false)
                    {
                        if (forceRegister.ContainsKey(side) == false)
                        {
                            forceRegister.Add(side, new List<String>());
                        }

                        forceRegister[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        foreach (var s in forceRegister)
                        {
                            if (s.Value.Contains(user))
                            {
                                s.Value.Remove(user);
                            }
                        }

                        if (forceRegister.ContainsKey(side) == false)
                        {
                            forceRegister.Add(side, new List<string>());
                        }
                        forceRegister[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }

                input = Console.ReadLine();
            }
            foreach (var side in forceRegister.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");
                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}