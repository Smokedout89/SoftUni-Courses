using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int carsPassed = 0;

            Queue<string> queue = new Queue<string>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {

                if (command == "green")
                {
                    int currentGreenLight = greenLightDuration;

                    while (queue.Count > 0 && currentGreenLight > 0)
                    {
                        string currentCar = queue.Dequeue();

                        if (currentGreenLight - currentCar.Length >= 0)
                        {
                            currentGreenLight -= currentCar.Length;
                            carsPassed++;
                            continue;
                        }

                        if (currentGreenLight + freeWindowDuration - currentCar.Length >= 0)
                        {
                            carsPassed++;
                            currentGreenLight = 0;
                            continue;
                        }

                        int hittedChar = currentGreenLight + freeWindowDuration;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {currentCar[hittedChar]}.");

                        Environment.Exit(0);
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
