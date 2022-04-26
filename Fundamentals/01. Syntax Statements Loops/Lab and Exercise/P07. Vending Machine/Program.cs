using System;

namespace P07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            double price = 0;

            while (input != "Start")
            {
                switch (input)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        sum += double.Parse(input);
                        break;

                    default: Console.WriteLine($"Cannot accept {input}"); break;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                switch (input)
                {
                    case "Nuts": price = 2; break;
                    case "Water": price = 0.7; break;
                    case "Crisps": price = 1.5; break;
                    case "Soda": price = 0.8; break;
                    case "Coke": price = 1; break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                if (sum >= price && price > 0)
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                    sum -= price;
                }
                else if (price > 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
