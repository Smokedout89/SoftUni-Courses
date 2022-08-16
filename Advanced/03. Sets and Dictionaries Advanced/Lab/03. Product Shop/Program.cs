using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string,double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            string command;

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] cmdArgs = command.Split(", ");
                string shopName = cmdArgs[0];
                string product = cmdArgs[1];
                double price = double.Parse(cmdArgs[2]);
                
                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                shops[shopName].Add(product, price);
            }

            Dictionary<string, Dictionary<string, double>> orderedShops = shops.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var orderedShop in orderedShops)
            {
                Console.WriteLine($"{orderedShop.Key}->");

                foreach (var product in orderedShop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
