using System;

namespace GodzillaVSKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int numberOfStatists = int.Parse(Console.ReadLine());
            double clothingPPS = double.Parse(Console.ReadLine());

            double decor = budged * 0.1;

            if (numberOfStatists > 150)
            {
                clothingPPS = clothingPPS * 0.9;
            }

            double difference = Math.Abs(numberOfStatists * clothingPPS + decor - budged);

            if (budged >= numberOfStatists*clothingPPS + decor)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {difference:f2} leva left.");
            }

            else
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {difference:f2} leva more.");
            }
        }
    }
}
