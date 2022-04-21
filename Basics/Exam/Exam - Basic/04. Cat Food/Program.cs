using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            const double kgFood = 12.45;
            int numOfCats = int.Parse(Console.ReadLine());
            int smallCats = 0;
            int mediumCats = 0;
            int largeCats = 0;
            double totalGramsOfFoodEaten = 0;

            for (int i = 0; i < numOfCats; i++)
            {
                double foodEatenByCat = double.Parse(Console.ReadLine());
                if (foodEatenByCat < 200)
                {
                    smallCats++;
                    totalGramsOfFoodEaten += foodEatenByCat;
                }
                else if (foodEatenByCat < 300)
                {
                    mediumCats++;
                    totalGramsOfFoodEaten += foodEatenByCat;
                }
                else
                {
                    largeCats++;
                    totalGramsOfFoodEaten += foodEatenByCat;
                }
            }

            double totalFoodInKG = totalGramsOfFoodEaten / 1000;
            double priceForFood = totalFoodInKG * kgFood;

            Console.WriteLine($"Group 1: {smallCats} cats.");
            Console.WriteLine($"Group 2: {mediumCats} cats.");
            Console.WriteLine($"Group 3: {largeCats} cats.");
            Console.WriteLine($"Price for food per day: {priceForFood:f2} lv.");
        }
    }
}
