using System;

namespace _03._Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double pricePerPerson = 0;

            if (numberOfPeople <= 5)
            {
                switch (season)
                {
                    case "spring":
                        pricePerPerson = 50.00;
                        break;
                    case "summer":
                        pricePerPerson = 48.50;
                        break;
                    case "autumn":
                        pricePerPerson = 60.00;
                        break;
                    case "winter":
                        pricePerPerson = 86.00;
                        break;
                }
            }
            else
            {
                switch (season)
                {
                    case "spring":
                        pricePerPerson = 48.00;
                        break;
                    case "summer":
                        pricePerPerson = 45.00;
                        break;
                    case "autumn":
                        pricePerPerson = 49.50;
                        break;
                    case "winter":
                        pricePerPerson = 85.00;
                        break;
                }
            }

            double price = numberOfPeople * pricePerPerson;
            if (season == "summer")
            {
                price *= 0.85;
            }
            else if (season == "winter")
            {
                price *= 1.08;
            }

            Console.WriteLine($"{price:f2} leva.");

        }
    }
}
