using System;

namespace _05._Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int startingPoint = 5364;
            int finishPoint = 8848;
            int daysCounter = 1;

            while (input != "END")
            {
                int metres = int.Parse(Console.ReadLine());
                if (input == "Yes")
                {
                    daysCounter++;
                    if (daysCounter > 5)
                    {
                        break;
                    }
                    startingPoint += metres;
                }
                else
                {
                    startingPoint += metres;
                }

                if (startingPoint>=finishPoint)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            if (startingPoint >= finishPoint)
            {
                Console.WriteLine($"Goal reached for {daysCounter} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{startingPoint}");
            }
  
        }
    }
}
