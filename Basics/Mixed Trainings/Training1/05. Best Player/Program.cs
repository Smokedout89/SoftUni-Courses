using System;

namespace _05._Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            string currentBestPlayer = "";
            int currentMostGoals = 0;
            while (playerName != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if (goals >= 10)
                {
                    currentMostGoals = goals;
                    currentBestPlayer = playerName;
                    break;
                }
                else if (goals > currentMostGoals)
                {
                    currentMostGoals = goals;
                    currentBestPlayer = playerName;
                }
                playerName = Console.ReadLine();              
            }
            Console.WriteLine($"{currentBestPlayer} is the best player!");
            if (currentMostGoals >= 3)
            {
            Console.WriteLine($"He has scored {currentMostGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {currentMostGoals} goals.");
            }
        }
    }
}
