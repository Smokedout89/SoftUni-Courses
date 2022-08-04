using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int reward = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int totalBulletsShot = 0;
            int currBulletsShot = 0;

            while (bulletStack.Count > 0 && locksQueue.Count > 0)
            {
                int currentBullet = bulletStack.Pop();
                totalBulletsShot++;
                currBulletsShot++;

                if (currentBullet <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currBulletsShot == barrelSize && bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currBulletsShot = 0;
                }
            }

            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int moneyEarned = reward - totalBulletsShot * bulletPrice;
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
