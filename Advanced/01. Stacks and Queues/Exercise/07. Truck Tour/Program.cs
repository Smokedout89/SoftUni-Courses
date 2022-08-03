using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolStations = int.Parse(Console.ReadLine());
            Queue<int[]> petrolPumps = new Queue<int[]>();

            for (int i = 0; i < petrolStations; i++)
            {
                int[] petrolPump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrolPumps.Enqueue(petrolPump);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (int[] petrolPump in petrolPumps)
                {
                    int petrol = petrolPump[0];
                    int distance = petrolPump[1];

                    totalFuel += petrol - distance;

                    if (totalFuel < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
