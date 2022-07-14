using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12_._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] token = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = token[0];

                if (action == "Collect")
                {
                    string item = token[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }   
                else if (action == "Drop")
                {
                    string item = token[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (action == "Combine Items")
                {
                    string itemsToSplit = token[1];
                    string[] itemsToCombine = itemsToSplit.Split(':');
                    string oldItem = itemsToCombine[0];
                    string newItem = itemsToCombine[1];

                    if (items.Contains(oldItem))
                    {
                        int index = items.IndexOf(oldItem);
                        items.Insert(index + 1, newItem);
                    }
                }
                else if (action == "Renew")
                {
                    string item = token[1];

                    if (items.Contains(item))
                    {
                        string oldItem = item;
                        items.Remove(item);
                        items.Add(oldItem);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
