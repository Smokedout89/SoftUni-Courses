using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodInKg = int.Parse(Console.ReadLine());
            int foodInGrams = foodInKg * 1000;

            string input = Console.ReadLine();

            int totalFoodEaten = 0;

            while (input != "Adopted")
            {
                int foodEaten = int.Parse(input);
                totalFoodEaten += foodEaten;

                input = Console.ReadLine();
            }

            if (foodInGrams >= totalFoodEaten)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodInGrams-totalFoodEaten} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {totalFoodEaten-foodInGrams} grams more.");
            }
        }
    }
}
