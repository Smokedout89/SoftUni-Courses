using System;
using System.Linq;

namespace P09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            int[] bestDNA = new int[sequenceLength];

            int dnaSum = 0;
            int dnaCount = -1;
            int dnaStartIndex = -1;
            int dnaSample = 0;

            int sample = 0;
            string input;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                sample++;

                int[] currentDNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentLengthCount = 0;
                int currentDNASum = 0;
                int currentStartIndex = 0;
                int currentEndIndex = 0;
                bool isCurrentDNABetter = false;

                int lengthCount = 0;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] != 1)
                    {
                        lengthCount = 0;
                        continue;
                    }

                    lengthCount++;

                    if (lengthCount > currentLengthCount)
                    {
                        currentLengthCount = lengthCount;
                        currentEndIndex = i;
                    }
                }

                currentStartIndex = currentEndIndex - currentLengthCount + 1;
                currentDNASum = currentDNA.Sum();

                if (currentLengthCount > dnaCount)
                {
                    isCurrentDNABetter = true;
                }
                else if (currentLengthCount == dnaCount)
                {
                    if (currentStartIndex < dnaStartIndex)
                    {
                        isCurrentDNABetter = true;
                    }
                    else if (currentStartIndex == dnaStartIndex)
                    {
                        if (currentDNASum > dnaSum)
                        {
                            isCurrentDNABetter = true;
                        }
                    }
                }

                if (isCurrentDNABetter)
                {
                    bestDNA = currentDNA;
                    dnaCount = currentLengthCount;
                    dnaStartIndex = currentStartIndex;
                    dnaSum = currentDNASum;
                    dnaSample = sample;
                }

            }

            Console.WriteLine($"Best DNA sample {dnaSample} with sum: {dnaSum}.");
            Console.WriteLine(String.Join(' ', bestDNA));
        }
    }
}
