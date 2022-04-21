using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double luggageOver20 = double.Parse(Console.ReadLine());
            double luggageKG = double.Parse(Console.ReadLine());
            int daysTillTrip = int.Parse(Console.ReadLine());
            int numberOfLuggage = int.Parse(Console.ReadLine());

            double luggagePrice = 0;

            if (luggageKG < 10)
            {
                luggagePrice = luggageOver20 * 0.2;
            }
            else if (luggageKG <= 20)
            {
                luggagePrice = luggageOver20 * 0.5;
            }
            else
            {
                luggagePrice = luggageOver20;
            }

            if (daysTillTrip < 7)
            {
                luggagePrice *=  1.4;
            }
            else if (daysTillTrip >= 7 && daysTillTrip <= 30)
            {
                luggagePrice *= 1.15;
            }
            else
            {
                luggagePrice *= 1.10;
            }
            double price = numberOfLuggage * luggagePrice;
            Console.WriteLine($"The total price of bags is: {price:f2} lv.");
        }
    }
}
