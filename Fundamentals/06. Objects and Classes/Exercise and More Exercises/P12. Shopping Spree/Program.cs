using System;
using System.Linq;
using System.Collections.Generic;

namespace P11._Shopping_Spree
{
    class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name { get; set; }

        public decimal Money { get; set; }

        public List<string> Bag { get; set; } = new List<string>();

        public void BuyProduct(Product productToBuy)
        {
            if (this.Money >= productToBuy.Price)
            {
                this.Bag.Add(productToBuy.Name);
                this.Money -= productToBuy.Price;
                Console.WriteLine($"{this.Name} bought {productToBuy.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {productToBuy.Name}");
            }
        }
    }

    class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();

            string[] cmdPeople = Console.ReadLine().Split(';').ToArray();

            foreach (var person in cmdPeople)
            {
                string name = person.Split('=')[0];
                decimal money = decimal.Parse(person.Split('=')[1]);
                people.Add(new Person(name, money));
            }

            string[] cmdProducts = Console.ReadLine().Split(';').ToArray();

            foreach (var product in cmdProducts)
            {
                string name = product.Split('=')[0];
                decimal price = decimal.Parse(product.Split('=')[1]);
                products.Add(new Product(name, price));
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string personName = command.Split()[0];
                string productToBuy = command.Split()[1];

                people.Find(p => p.Name == personName).BuyProduct(products.Find(p => p.Name == productToBuy));

                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
