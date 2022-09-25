using System;
using System.Linq;
using System.Collections.Generic;

namespace Warm_Winter
{
    internal class WarmWinter
    {
        static void Main(string[] args)
        {
            List<int> hats = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            List<int> sets = new List<int>();

            int mostExpensiveSet = 0;

            while (hats.Count != 0 && scarfs.Count != 0)
            {
                int currHat = hats[hats.Count - 1];
                int currScarf = scarfs.Peek();

                if (currHat > currScarf)
                {
                    int currSet = currHat + currScarf;
                    sets.Add(currSet);

                    if (currSet > mostExpensiveSet)
                    {
                        mostExpensiveSet = currSet;
                    }

                    hats.RemoveAt(hats.Count - 1);
                    scarfs.Dequeue();

                }
                else if (currScarf > currHat)
                {
                    hats.RemoveAt(hats.Count - 1);
                }
                else if (currHat == currScarf)
                {
                    scarfs.Dequeue();
                    hats[hats.Count - 1]++;
                }
            }

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine($"{string.Join(' ', sets)}");
        }
    }
}
