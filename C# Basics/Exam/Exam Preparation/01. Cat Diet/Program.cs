using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double fatPercent = int.Parse(Console.ReadLine());
            double proteinPercent = int.Parse(Console.ReadLine());
            double carbohydratesPercent = int.Parse(Console.ReadLine());
            double calories = int.Parse(Console.ReadLine());
            double waterPercent = int.Parse(Console.ReadLine());
            double water = 100;

            double fat = calories / 100 * fatPercent / 9;
            double protein = calories / 100 * proteinPercent / 4;
            double carbohydrates = calories / 100 * carbohydratesPercent / 4;
            double foodTotal = fat + protein + carbohydrates;
            double caloriesPerGram = calories / foodTotal;
            double waterPercentageLeft = water - waterPercent;

            caloriesPerGram = caloriesPerGram / 100 * waterPercentageLeft;

            Console.WriteLine($"{caloriesPerGram:f4}");
        }
    }
}
