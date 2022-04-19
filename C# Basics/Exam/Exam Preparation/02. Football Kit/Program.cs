using System;

namespace _02._Football_Kit
{
    class Program
    {
        static void Main(string[] args)
        {
            double shirtPrice = double.Parse(Console.ReadLine());
            double moneyToReach = double.Parse(Console.ReadLine());

            double shortPrice = shirtPrice * 0.75;
            double socksPrice = shortPrice * 0.20;
            double buttonsPrice = (shortPrice + shirtPrice) * 2;

            double totalPriceAfterDiscount = (shirtPrice + shortPrice + socksPrice + buttonsPrice) * 0.85;

            if (totalPriceAfterDiscount >= moneyToReach)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalPriceAfterDiscount:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {moneyToReach - totalPriceAfterDiscount:f2} lv. more.");
            }
           
        }
    }
}
