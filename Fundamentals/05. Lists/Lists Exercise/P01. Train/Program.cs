using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> passangers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] token = command.Split();

                if (token[0] == "Add")
                {
                    int wagonToAdd = int.Parse(token[1]);
                    passangers.Add(wagonToAdd);
                }
                else
                {
                    int currPassangers = int.Parse(token[0]);
                    for (int i = 0; i < passangers.Count; i++)
                    {
                        if (passangers[i] + currPassangers <= maxCapacity )
                        {
                            passangers[i] += currPassangers;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', passangers));
        }
    }
}
