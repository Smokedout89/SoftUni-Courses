using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int targetSteps = 10000;
            int stepsCounter = 0;
          
            while (stepsCounter < targetSteps)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    int stepsGoingHome = int.Parse(Console.ReadLine());
                    stepsCounter += stepsGoingHome;
                    break;
                }              
                int steps = int.Parse(input);
                stepsCounter += steps;
            }

            if (stepsCounter >= targetSteps)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsCounter-targetSteps} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{targetSteps-stepsCounter} more steps to reach goal.");
            }
        }
    }
}
