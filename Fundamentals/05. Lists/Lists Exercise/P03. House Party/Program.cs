using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < number; i++)
            {
                string[] token = Console.ReadLine().Split(' ');
                string name = token[0];

                if (token.Length == 3)
                {

                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (var name in guests)
            {
                Console.WriteLine(name);
            }
        }
    }
}
