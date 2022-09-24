using System;
using System.Linq;
using System.Collections.Generic;

namespace The_Fight_for_Gondor
{
    internal class TheFightForGondor
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> platesQue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> attackStack = new Stack<int>();
            bool orcsWon = false;

            for (int i = 1; i <= waves; i++)
            {
                if (orcsWon)
                {
                    break;
                }

                attackStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    platesQue.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (platesQue.Count != 0 && attackStack.Count != 0)
                {
                    int currPlate = platesQue.Peek();
                    int currAttack = attackStack.Peek();

                    if (currAttack > currPlate)
                    {
                        attackStack.Push(attackStack.Pop() - platesQue.Dequeue());
                    }
                    else if (currPlate > currAttack)
                    {
                        Queue<int> updatedQue = new Queue<int>();
                        
                        updatedQue.Enqueue(platesQue.Dequeue() - attackStack.Pop());

                        foreach (var item in platesQue)
                        {
                            updatedQue.Enqueue(item);
                        }

                        platesQue = updatedQue;
                    }
                    else
                    {
                        attackStack.Pop();
                        platesQue.Dequeue();
                    }

                    if (platesQue.Count == 0)
                    {
                        orcsWon = true;
                        break;
                    }
                }
            }

            if (orcsWon)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", attackStack)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesQue)}");
            }
        }
    }
}
