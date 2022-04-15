using System;

namespace _06._Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int daysCount = 0;
            double ticketPrice = 0;
            double dailyTax = 0;
            double totalTax = 0;
            for (int i = 1; i <= day; i++)
            {
                daysCount++;
                dailyTax = 0;
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 !=0)
                    {
                        ticketPrice = 2.50;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        ticketPrice = 1.25;
                    }
                    else
                    {
                        ticketPrice = 1;
                    }
                    dailyTax += ticketPrice;
                }
                totalTax += dailyTax;
                Console.WriteLine($"Day: {daysCount} - {dailyTax:f2} leva");
            }

            Console.WriteLine($"Total: {totalTax:f2} leva");
        }
    }
}
