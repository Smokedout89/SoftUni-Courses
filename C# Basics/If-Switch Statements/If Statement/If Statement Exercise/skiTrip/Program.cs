using System;

namespace skiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            const double roomForOnePerson = 18;
            const double apartament = 25;
            const double presidentialApartament = 35;

            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string evaluating = Console.ReadLine();

            double totalPrice = 0;
            int nights = days - 1;

            switch (type)
            {
                case "room for one person":
                    totalPrice = nights * roomForOnePerson;
                    break;
                case "apartment":
                    totalPrice = nights * apartament;
                    if (nights > 15)
                    {
                        totalPrice *= 0.5;
                    }
                    else if (nights > 10)
                    {
                        totalPrice *= 0.65;
                    }
                    else
                    {
                        totalPrice *= 0.7;
                    }
                    break;
                case "president apartment":
                    totalPrice = nights * presidentialApartament;
                    if (nights > 15)
                    {
                        totalPrice *= 0.8;
                    }
                    else if (nights > 10)
                    {
                        totalPrice *= 0.85;
                    }
                    else
                    {
                        totalPrice *= 0.9;
                    }
                    break;
            }
            switch (evaluating)
            {
                case "positive":
                    totalPrice = totalPrice * 1.25;
                    break;
                case "negative":
                    totalPrice = totalPrice * 0.9;
                    break;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
