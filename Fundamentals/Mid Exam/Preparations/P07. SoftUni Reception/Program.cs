using System;

namespace Problem_7___SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEfficiency = int.Parse(Console.ReadLine());
            int secondEfficiency = int.Parse(Console.ReadLine());
            int thirdEfficiency = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int hoursNeeded = 0;
            int totalEfficiency = firstEfficiency + secondEfficiency + thirdEfficiency;

            while (students > 0)
            {
                hoursNeeded++;

                if (hoursNeeded % 4 == 0 )
                {
                    continue;
                }

                students -= totalEfficiency;
            }

            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
