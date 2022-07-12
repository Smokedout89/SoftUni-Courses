using System;

namespace Problem_1___Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            decimal price = 0.0m;
            decimal totalTax = 0.0m;

            while (input != "special" && input != "regular")
            {
                decimal currentPrice = decimal.Parse(input);
                decimal currentTax = currentPrice * (decimal)0.2;

                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    totalTax += currentTax;
                    price += currentPrice;
                }

                input = Console.ReadLine();
            }

            decimal totalPrice = totalTax + price;

            if (input == "special")
            {
                totalPrice *= (decimal)0.9;
            }

            if (price == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {price:f2}$");
                Console.WriteLine($"Taxes: {totalTax:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }

        }
    }
}
