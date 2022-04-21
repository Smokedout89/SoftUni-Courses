using System;

namespace fishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishermans = int.Parse(Console.ReadLine());

            double rent = 0;
     
            switch (season)
            {
                case "Spring":
                    rent = 3000;
                    if (numberOfFishermans <= 6)
                    {
                        rent = rent * 0.9;
                    }
                    else if (numberOfFishermans >= 7 && numberOfFishermans <= 11)
                    {
                        rent = rent * 0.85;
                    }
                    else rent = rent * 0.75;
                    break;
                case "Summer":
                    rent = 4200;
                    if (numberOfFishermans <= 6)
                    {
                        rent = rent * 0.9;
                    }
                    else if (numberOfFishermans >= 7 && numberOfFishermans <= 11)
                    {
                        rent = rent * 0.85;
                    }
                    else rent = rent * 0.75;
                    break;
                case "Autumn":
                    rent = 4200;
                    if (numberOfFishermans <= 6)
                    {
                        rent = rent * 0.9;
                    }
                    else if (numberOfFishermans >= 7 && numberOfFishermans <= 11)
                    {
                        rent = rent * 0.85;
                    }
                    else rent = rent * 0.75;
                    break;
                case "Winter":
                    rent = 2600;
                    if (numberOfFishermans <= 6)
                    {
                        rent = rent * 0.9;
                    }
                    else if (numberOfFishermans >= 7 && numberOfFishermans <= 11)
                    {
                        rent = rent * 0.85;
                    }
                    else rent = rent * 0.75;
                    break;
            }
            if (numberOfFishermans % 2 == 0 && season != "Autumn")
            {
                rent = rent * 0.95;
            }

            if (budget >= rent)
            {
                Console.WriteLine($"Yes! You have {budget-rent:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rent-budget:f2} leva.");
            }
        }
    }
}
