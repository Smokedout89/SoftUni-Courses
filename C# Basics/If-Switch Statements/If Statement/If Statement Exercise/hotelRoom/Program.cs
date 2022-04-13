using System;

namespace hotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double priceStudio = 0;
            double priceApartament = 0;

            if (month == "May" || month == "October")
            {
                priceApartament = nights * 65;
                priceStudio = nights * 50;
                if (nights > 7 && nights < 14)
                {
                    priceStudio *= 0.95;
                }
                else if (nights > 14)
                {
                    priceStudio *= 0.70;
                    priceApartament *= 0.9;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceApartament = nights * 68.70;
                priceStudio = nights * 75.20;
                if (nights > 14)
                {
                    priceStudio *= 0.80;
                    priceApartament *= 0.90;
                }
            }
            else if (month == "July" || month == "August")
            {
                priceApartament = nights * 77;
                priceStudio = nights * 76;  
                if (nights > 14)
                {
                    priceApartament *= 0.90;
                }
            }
            Console.WriteLine($"Apartment: {priceApartament:f2} lv.");
            Console.WriteLine($"Studio: {priceStudio:f2} lv.");
        }
    }
}
