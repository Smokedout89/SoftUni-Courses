using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();

            while (command != "Print")
            {
                string[] cmdArgs = command.Split(';');
                string cmd = cmdArgs[0];
                string operation = cmdArgs[1];
                string value = cmdArgs[2];

                if (cmd == "Add filter")
                {
                    allFilters.Add(operation + value, GetPredicate(operation, value));
                }
                else
                {
                    allFilters.Remove(operation + value);
                }

                command = Console.ReadLine();
            }

            foreach (var (key, value) in allFilters)
            {
                names.RemoveAll(value);
            }

            Console.WriteLine(string.Join(' ', names));
        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {
            if (operation == "Starts with")
            {
                return x => x.StartsWith(value);
            }

            if (operation == "Ends with")
            {
                return x => x.EndsWith(value);
            }

            if (operation == "Contains")
            {
                return x => x.Contains(value);
            }

            int valueAsInt = int.Parse(value);

            return x => x.Length == valueAsInt;
        }
    }
}
