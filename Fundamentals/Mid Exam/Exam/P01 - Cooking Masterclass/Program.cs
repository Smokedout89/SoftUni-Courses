using System;

namespace P01___Cooking_Masterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            double studentsForApron = Math.Ceiling(students + students * 0.2);
            int freeFlour = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    freeFlour++;
                }
            }

            double totalSpent = (apronPrice * studentsForApron) + (eggPrice * 10 * students) +
                                     (flourPrice * (students - freeFlour));

            if (budget >= totalSpent)
            {
                Console.WriteLine($"Items purchased for {totalSpent:f2}$.");
            }
            else
            {
                double moneyNeeded = totalSpent - budget;
                Console.WriteLine($"{moneyNeeded:f2}$ more needed.");
            }
        }
    }
}
