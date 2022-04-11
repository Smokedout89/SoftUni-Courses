using System;

namespace Toy_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double puzzlePrice = 2.60;
            const double dollPrice = 3;
            const double bearPrice = 4.10;
            const double minionPrice = 8.20;
            const double truckPrice = 2;           

            double trip = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double totalPrice = puzzle * puzzlePrice + dolls * dollPrice + bears * bearPrice + minions * minionPrice + trucks * truckPrice;
            int toysCounter = puzzle + dolls + bears + minions + trucks;

            if (toysCounter >= 50)
            {
                totalPrice *= 0.75; 
            }

            double rent = totalPrice * 0.1;
            double difference = Math.Abs(rent + trip - totalPrice);

            if (totalPrice >= rent + trip)
            {
                Console.WriteLine($"Yes! {difference:f2} lv left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
            }

        }
    }
}
