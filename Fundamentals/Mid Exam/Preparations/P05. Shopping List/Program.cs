using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5___Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] token = command.Split();
                string input = token[0];
                string product = token[1];

                if (input == "Urgent")
                {
                    if (!products.Contains(product))
                    {
                        products.Insert(0, product);
                    }
                }
                else if (input == "Unnecessary")
                {
                    if (products.Contains(product))
                    {
                        products.Remove(product);
                    }
                }
                else if (input == "Correct")
                {
                    string newProduct = token[2];
                    if (products.Contains(product))
                    {
                        int index = products.IndexOf(product);
                        products.Insert(index, newProduct);
                        products.Remove(product);
                    }
                }
                else if (input == "Rearrange")
                {
                    if (products.Contains(product))
                    {
                        products.Remove(product);
                        products.Add(product);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", products));
        }
    }
}
