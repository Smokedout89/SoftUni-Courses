using System;

namespace _04._Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            int productCount = 0;
            double moneySpentCount = 0;
            while (product != "Stop")
            {
                productCount++;
                double productPrice = double.Parse(Console.ReadLine());
                if (productCount % 3 == 0)
                {
                    productPrice /= 2;
                }
                if (productPrice > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {productPrice - budget:f2} leva!");
                    break;
                }
                moneySpentCount += productPrice;
                budget -= productPrice;
                product = Console.ReadLine();
            }
            if (product == "Stop")
            {
                Console.WriteLine($"You bought {productCount} products for {moneySpentCount:f2} leva.");
            }

        }
    }
}
