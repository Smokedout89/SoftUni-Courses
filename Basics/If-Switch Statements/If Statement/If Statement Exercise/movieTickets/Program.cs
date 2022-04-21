using System;

namespace movieTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            const double Premiere = 12, Normal = 7.50, Discount = 5;

            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double income = 0;

            switch (type)
            {
                case "Premiere":
                    income = rows * colums * Premiere;
                    break;
                case "Normal":
                    income = rows * colums * Normal;
                    break;
                case "Discount":
                    income = rows * colums * Discount;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{income:f2} leva");
        }
    }
}
