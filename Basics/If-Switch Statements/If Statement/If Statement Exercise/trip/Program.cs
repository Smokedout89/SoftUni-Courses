using System;

namespace trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string typeOfHoliday = "";
            double moneyLeft = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";

                switch (season)
                {
                    case "summer":
                        moneyLeft += budget * 0.3;
                        break;
                    case "winter":
                        moneyLeft += budget * 0.7;
                        break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                switch (season)
                {
                    case "summer":
                        moneyLeft += budget * 0.4;
                        break;
                    case "winter":
                        moneyLeft += budget * 0.8;
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                moneyLeft += budget * 0.9;
            }
          
           if (season == "winter" || destination == "Europe")
           {
                typeOfHoliday = "Hotel";
           }
            else if (season == "summer")
            {
                typeOfHoliday = "Camp";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfHoliday} - {moneyLeft:f2}");
           
        }
    }
}
