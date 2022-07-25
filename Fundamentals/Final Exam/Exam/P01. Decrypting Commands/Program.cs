using System;

namespace _01._Decrypting_Commands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];

                if (action == "Replace")
                {
                    string currCh = cmdArgs[1];
                    string newCh = cmdArgs[2];

                    inputStr = inputStr.Replace(currCh, newCh);

                    Console.WriteLine(inputStr);
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if (IndexValidation(inputStr, startIndex, endIndex))
                    {
                        inputStr = inputStr.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(inputStr);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (action == "Make")
                {
                    string lowerOrUpper = cmdArgs[1];

                    if (lowerOrUpper == "Upper")
                    {
                        inputStr = inputStr.ToUpper();
                    }
                    else if (lowerOrUpper == "Lower")
                    {
                        inputStr = inputStr.ToLower();
                    }

                    Console.WriteLine(inputStr);
                }
                else if (action == "Check")
                {
                    string strToCheck = cmdArgs[1];

                    if (inputStr.Contains(strToCheck))
                    {
                        Console.WriteLine($"Message contains {strToCheck}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {strToCheck}");
                    }
                }
                else if (action == "Sum")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if (IndexValidation(inputStr, startIndex, endIndex))
                    {
                        int sum = 0;
                        string inputToSum = inputStr.Substring(startIndex, endIndex - startIndex + 1);

                        foreach (var ch in inputToSum)
                        {
                            sum += ch;
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }

                command = Console.ReadLine();
            }
        }

        static bool IndexValidation(string input, int startIndex, int endIndex)
        {
            return startIndex >= 0 && endIndex < input.Length;
        }
    }
}
