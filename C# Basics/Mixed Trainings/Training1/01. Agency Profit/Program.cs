using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string aviocompany = Console.ReadLine();
            int adultTickets = int.Parse(Console.ReadLine());
            int kidsTickets = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double kidsTicketPrice = adultTicketPrice - adultTicketPrice * 0.7;
            double adultTicketAfterTax = adultTicketPrice + tax;
            double kidsTicketAfterTax = kidsTicketPrice + tax;

            double totalTickets = adultTickets * adultTicketAfterTax + kidsTickets * kidsTicketAfterTax;
            double totalProfit = totalTickets * 0.2;

            Console.WriteLine($"The profit of your agency from {aviocompany} tickets is {totalProfit:f2} lv.");
        }
    }
}
