using System;

namespace _06._Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seatsOnOddRow = int.Parse(Console.ReadLine());
            int seatsOnEvenRow = 0;
            int totalSeats = 0;

            for (char i = 'A'; i <= sector; i++, rows++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    seatsOnEvenRow = (j % 2 == 0) ? 2 : 0;
                    for (char k = 'a'; k < 'a' + seatsOnOddRow + seatsOnEvenRow; k++)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                        totalSeats++;
                    }
                }
            }

            Console.WriteLine(totalSeats);

        }
    }
}
