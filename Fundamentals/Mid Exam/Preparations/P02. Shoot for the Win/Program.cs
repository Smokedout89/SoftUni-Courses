using System;
using System.Linq;

namespace Problem_2._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();
            int targetsShot = 0;

            while (input != "End")
            {
                int indexToShoot = int.Parse(input);

                if (indexToShoot >= 0 && indexToShoot < sequence.Length && indexToShoot != -1)
                {
                    int currNum = sequence[indexToShoot];
                    sequence[indexToShoot] = -1;
                    targetsShot++;

                    for (int j = 0; j < sequence.Length; j++)
                    {
                        if (sequence[j] != -1 && sequence[j] > currNum)
                        {
                            sequence[j] -= currNum;
                        }
                        else if (sequence[j] != -1 && sequence[j] <= currNum)
                        {
                            sequence[j] += currNum;
                        }
                    }
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {targetsShot} -> {string.Join(' ', sequence)}");
        }
    }

}