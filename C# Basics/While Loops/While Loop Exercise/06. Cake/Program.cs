using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLenght = int.Parse(Console.ReadLine());
            int cake = cakeLenght * cakeWidth;                  
            while (cake > 0)
            {
               string input = Console.ReadLine();               
               if (input == "STOP")
               {
                    break;
               }
                int cakesTaken = int.Parse(input);
                cake -= cakesTaken;               
            }
            if (cake < 0 )
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
            }
            else if (cake >= 0)
            {
                Console.WriteLine($"{cake} pieces are left.");
            }          
        }
    }
}
