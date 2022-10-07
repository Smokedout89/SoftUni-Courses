using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionsCount = 0;

            while (exceptionsCount != 3)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];

                try
                {
                    bool isNum = CheckNum(command[1]);
                    bool isNum2 = true;

                    if (action != "Show")
                    {
                        isNum2 = CheckNum(command[2]);
                    }

                    if (!isNum || !isNum2)
                    {
                        exceptionsCount++;
                        throw new ArgumentException("The variable is not in the correct format!");
                    }

                    if (action == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);

                        if (CheckValidIndex(index, input))
                        {
                            input[index] = element;
                        }
                        else
                        {
                            exceptionsCount++;
                            throw new ArgumentException("The index does not exist!");
                        }
                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        if (CheckValidIndex(startIndex, input) && CheckValidIndex(endIndex, input))
                        {
                            List<int> output = new List<int>();

                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                output.Add(input[i]);
                            }

                            Console.WriteLine(string.Join(", ", output));
                        }
                        else
                        {
                            exceptionsCount++;
                            throw new ArgumentException("The index does not exist!");
                        }
                    }
                    else if (action == "Show")
                    {
                        int index = int.Parse(command[1]);

                        if (CheckValidIndex(index, input))
                        {
                            Console.WriteLine(input[index]);
                        }
                        else
                        {
                            exceptionsCount++;
                            throw new ArgumentException("The index does not exist!");
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(", ", input));
        }

        private static bool CheckValidIndex(int index, int[] input) => index >= 0 && index < input.Length;


        private static bool CheckNum(string item) => int.TryParse(item, out int result);
    }
}
