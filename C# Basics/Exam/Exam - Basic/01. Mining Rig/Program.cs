using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double videoCardPrice = int.Parse(Console.ReadLine());
            double switchPrice = int.Parse(Console.ReadLine());
            double electricityPerCardPerDay = double.Parse(Console.ReadLine());
            double profitPerCardPerDay = double.Parse(Console.ReadLine());

            double restOfComponents = 1000;

            double totalVideoCardPrice = videoCardPrice * 13;
            double totalSwitchPrice = switchPrice * 13;
            double totalMoneySpent = totalVideoCardPrice + totalSwitchPrice + restOfComponents;

            double dailyProfitPerCard = profitPerCardPerDay - electricityPerCardPerDay;
            double totalDailyProfit = dailyProfitPerCard * 13;

            double investmentReturn = totalMoneySpent / totalDailyProfit;

            Console.WriteLine(totalMoneySpent);
            Console.WriteLine($"{Math.Ceiling(investmentReturn)}");
        }
    }
}
