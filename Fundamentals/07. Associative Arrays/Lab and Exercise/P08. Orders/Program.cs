using System;
using System.Collections.Generic;
using System.Linq;

namespace P08._Orders
{
    internal class Program
    {
        class Product
        {
            public Product(string name, decimal price, int quantity)
            {
                this.Name = name;
                this.Price = price;
                this.Quantity = quantity;
            }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, Product> productPrices = new Dictionary<string, Product>();

            while (command != "buy")
            {
                string[] cmdArgs = command.Split().ToArray();
                string product = cmdArgs[0];
                decimal price = decimal.Parse(cmdArgs[1]);
                int quantity = int.Parse(cmdArgs[2]);

                if (!productPrices.ContainsKey(product))
                {
                    productPrices.Add(product, new Product(product, price, quantity));
                }
                else
                {
                    productPrices[product].Price = price;
                    productPrices[product].Quantity += quantity;
                }

                command = Console.ReadLine();
            }

            foreach (var product in productPrices)
            {
                Console.WriteLine($"{product.Value.Name} -> {(product.Value.Price * product.Value.Quantity):F2}");
            }


            //string command = Console.ReadLine();

            //Dictionary<string, decimal[]> productPrices = new Dictionary<string, decimal[]>();

            //while (command != "buy")
            //{
            //    string[] cmdArgs = command.Split().ToArray();
            //    string product = cmdArgs[0];
            //    decimal price = decimal.Parse(cmdArgs[1]);
            //    decimal quantity = decimal.Parse(cmdArgs[2]);

            //    if (!productPrices.ContainsKey(product))
            //    {
            //        productPrices.Add(product, new decimal[2]);
            //    }

            //    productPrices[product][0] = price;
            //    productPrices[product][1] += quantity;

            //    command = Console.ReadLine();
            //}

            //foreach (var product in productPrices)
            //{
            //    Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):F2}");
            //}
        }
    }
}
