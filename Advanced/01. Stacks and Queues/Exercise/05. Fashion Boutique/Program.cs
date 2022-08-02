using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCount = 0;
            Stack<int> stack = new Stack<int>(clothSequence);

            int currRackCapacity = rackCapacity;

            while (stack.Count > 0)
            {
                int currCloth = stack.Peek();

                if (currRackCapacity - currCloth == 0)
                {
                    rackCount++;
                    currRackCapacity = rackCapacity;
                    stack.Pop();
                }
                else if (currRackCapacity - currCloth < 0)
                {
                    rackCount++;
                    currRackCapacity = rackCapacity;
                }
                else
                {
                    if (stack.Count == 1)
                    {
                        rackCount++;
                    }
                    currRackCapacity -= currCloth;
                    stack.Pop();
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}
