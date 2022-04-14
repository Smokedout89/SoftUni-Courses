using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floorInput = int.Parse(Console.ReadLine());
            int apartmentInput = int.Parse(Console.ReadLine());

            for (int floor = floorInput; floor >= 1; floor--)
            {
                for (int apartment = 0; apartment < apartmentInput; apartment++)
                {
                    if (floor == floorInput)
                    {
                        Console.Write($"L{floor}{apartment} ");
                        continue;
                    }

                    if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{apartment} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{apartment} ");
                    }                
                }
                Console.WriteLine();
            }

        }
    }
}
