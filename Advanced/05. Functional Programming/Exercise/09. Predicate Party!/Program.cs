using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] cmdArgs = command.Split();
                string cmd = cmdArgs[0];
                string operation = cmdArgs[1];
                string value = cmdArgs[2];

                if (cmd == "Double")
                {
                   List<string> doubleNames = names.FindAll(GetPredicate(operation, value));

                   if (!doubleNames.Any())
                   {
                       command = Console.ReadLine();
                       continue;
                   }

                   int index = names.FindIndex(GetPredicate(operation, value));
                   names.InsertRange(index, doubleNames);
                }
                else
                {
                    names.RemoveAll(GetPredicate(operation, value));
                }

                command = Console.ReadLine(); 
            }

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {
            if (operation == "StartsWith")
            {
                return x => x.StartsWith(value);
            }

            if (operation == "EndsWith")
            {
                return x => x.EndsWith(value);
            }

            int valueAsInt = int.Parse(value);

            return x => x.Length == valueAsInt;
        }
    }
}
