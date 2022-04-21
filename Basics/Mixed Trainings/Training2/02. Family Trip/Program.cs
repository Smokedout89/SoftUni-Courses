using System;

namespace _02._Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double nightPrice = double.Parse(Console.ReadLine());
            int additionalExpensesPercent = int.Parse(Console.ReadLine());

            double totalNightsPrice = nights * nightPrice;
            if (nights > 7)
            {
                totalNightsPrice *= 0.95;
            }
            double additionalMoney = budget / 100 * additionalExpensesPercent;
            double totalExpenses = totalNightsPrice + additionalMoney;
            if (totalExpenses <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - totalExpenses:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{totalExpenses - budget:f2} leva needed.");
            }
        }
    }
}
