using System;

namespace _11._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLoads = int.Parse(Console.ReadLine());

            double loadedByBus = 0;
            double loadedByTruck = 0;
            double loadedByTrain = 0;

            for (int i = 0; i < numOfLoads; i++)
            {
                int loadTons = int.Parse(Console.ReadLine());

                if (loadTons <= 3)
                {
                    loadedByBus += loadTons;
                }
                else if (loadTons <= 11)
                {
                    loadedByTruck += loadTons;
                }
                else
                {
                    loadedByTrain += loadTons;
                }
            }

            double totalTons = loadedByBus + loadedByTrain + loadedByTruck;
            double totalPrice = (loadedByBus * 200) + (loadedByTruck * 175) + (loadedByTrain * 120);
            double averagePricePerTon = totalPrice / totalTons;

            double percentByBus = loadedByBus / totalTons * 100;
            double percentByTruck = loadedByTruck / totalTons * 100;
            double percentByTrain = loadedByTrain / totalTons * 100;

            Console.WriteLine($"{averagePricePerTon:f2}");
            Console.WriteLine($"{percentByBus:f2}%");
            Console.WriteLine($"{percentByTruck:f2}%");
            Console.WriteLine($"{percentByTrain:f2}%");
        }
    }
}
