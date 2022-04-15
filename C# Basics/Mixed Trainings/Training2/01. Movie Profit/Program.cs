
using System;

namespace _01._Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int cinemaPercent = int.Parse(Console.ReadLine());

            double dailyTicketsPrice = ticketPrice * tickets;
            double totalTicketsPrice = days * dailyTicketsPrice;
            double totalCinemaProfit = totalTicketsPrice / 100 * cinemaPercent;
            double totalMovieProfit = totalTicketsPrice - totalCinemaProfit;

            Console.WriteLine($"The profit from the movie {movie} is {totalMovieProfit:f2} lv.");
        }
    }
}
