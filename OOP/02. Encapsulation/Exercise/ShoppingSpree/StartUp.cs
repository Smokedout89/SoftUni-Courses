using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> personsKVP = new Dictionary<string, Person>();
            Dictionary<string, Product> productsKVP = new Dictionary<string, Product>();

            string[] personsInfo = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productInfo = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < personsInfo.Length; i += 2)
                {
                    string name = personsInfo[i];
                    decimal money = decimal.Parse(personsInfo[i + 1]);

                    personsKVP.Add(name, new Person(name, money));
                }

                for (int i = 0; i < productInfo.Length; i += 2)
                {
                    string name = productInfo[i];
                    decimal price = decimal.Parse(productInfo[i + 1]);

                    productsKVP.Add(name, new Product(name, price));
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] info = command.Split();
                    string personName = info[0];
                    string productName = info[1];

                    Person person = personsKVP[personName];
                    Product product = productsKVP[productName];

                    bool isAdded = person.AddProduct(product);

                    if (!isAdded)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }

                    command = Console.ReadLine();
                }

                foreach (var (name, person) in personsKVP)
                {
                    string product = person.Products.Count > 0
                        ? string.Join(", ", person.Products.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{name} - {product}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
