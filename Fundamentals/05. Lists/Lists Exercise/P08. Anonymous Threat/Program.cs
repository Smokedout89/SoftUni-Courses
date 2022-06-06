using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split().ToArray();
                string command = cmdArgs[0];

                if (command == "3:1")
                {
                    break;
                }

                if (command == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    if (startIndex < 0 || startIndex >= input.Count) startIndex = 0;
                    if (endIndex >= input.Count) endIndex = input.Count - 1;

                    StringBuilder merged = new StringBuilder();

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        merged.Append(input[startIndex]);
                        input.RemoveAt(startIndex);
                    }

                    input.Insert(startIndex, merged.ToString());
                }
                else if (command == "divide")
                {
                    int indexToDivide = int.Parse(cmdArgs[1]);
                    int partitionsToDivide = int.Parse(cmdArgs[2]);

                    string wordToDivide = input[indexToDivide];

                    if (partitionsToDivide > wordToDivide.Length)
                    {
                        return;
                    }

                    List<string> partitions = new List<string>();

                    int partitionsLength = wordToDivide.Length / partitionsToDivide;
                    int partitionReminder = wordToDivide.Length % partitionsToDivide;
                    int lastPartitionLength = partitionsLength + partitionReminder;

                    for (int i = 0; i < partitionsToDivide; i++)
                    {
                        char[] currentPartition;

                        if (i == partitionsToDivide - 1)
                        {
                            currentPartition = wordToDivide
                                .Skip(i * partitionsLength)
                                .Take(lastPartitionLength)
                                .ToArray();
                        }
                        else
                        {
                            currentPartition = wordToDivide
                                .Skip(i * partitionsLength)
                                .Take(partitionsLength)
                                .ToArray();
                        }

                        partitions.Add(new string(currentPartition));
                    }

                    input.RemoveAt(indexToDivide);
                    input.InsertRange(indexToDivide, partitions);
                }

            }

            Console.WriteLine(string.Join(' ', input));
        }

    }
}
