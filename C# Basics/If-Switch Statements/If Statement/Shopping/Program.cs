using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {           
            double budget = double.Parse(Console.ReadLine());
            int videocards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            const double videoPrice = 250;
            double processorPrice = (videocards * videoPrice) * 0.35;
            double ramPrice = (videocards * videoPrice) * 0.1;

            double totalSum = videocards * videoPrice + processors * processorPrice + ram * ramPrice;

            if (videocards > processors)
            {
                // totalSum *= 0.85;
                totalSum = totalSum - totalSum * 0.15;
            }

            if (budget >= totalSum)
            {
                Console.WriteLine($"You have {budget - totalSum:f2} leva left!");
            }
            else Console.WriteLine($"Not enough money! You need {totalSum - budget:f2} leva more!");
         }
    }
}
