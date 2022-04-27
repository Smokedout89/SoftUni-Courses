using System;

namespace P09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceLightsaber = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double bonusLighsabers = Math.Ceiling(students * 0.1);
            int freeBelts = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 6 == 0)
                {
                    freeBelts++;
                }
            }

            double totalLightsabers = priceLightsaber * (students + bonusLighsabers);
            double totalRobes = priceRobes * students;
            double totalBelts = priceBelts * (students - freeBelts);

            double totalMoneyNeeded = totalBelts + totalLightsabers + totalRobes;

            if (money >= totalMoneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {totalMoneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalMoneyNeeded - money:f2}lv more.");
            }
        }
    }
}
