using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int totalSpace = width * lenght * height;
            int sumOfCubicMetres = 0;
            string input = Console.ReadLine();
            while (input != "Done")
            {
                int currentCubicMetres = int.Parse(input);           
                sumOfCubicMetres += currentCubicMetres;
                if (totalSpace < sumOfCubicMetres)
                {
                    int spaceNeeded = sumOfCubicMetres - totalSpace;
                    Console.WriteLine($"No more free space! You need {spaceNeeded} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();    
            }
            if (input == "Done")
            {
                Console.WriteLine($"{totalSpace-sumOfCubicMetres} Cubic meters left.");
            }     
        }
    }
}
