using System;

namespace _07._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string action = Console.ReadLine();

            while (action != "Travel")
            {
                string[] cmdArgs = action.Split(':');
                string command = cmdArgs[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string toInsert = cmdArgs[2];

                    if (IsIndexValid(input, index))
                    {
                        input = input.Insert(index, toInsert);
                    }

                    Console.WriteLine(input);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if (IsIndexValid(input, startIndex) && IsIndexValid(input, endIndex))
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(input);
                }
                else if (command == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];

                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                    }

                    Console.WriteLine(input);
                }

                action = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }

        static bool IsIndexValid(string input, int index)
        {
            return index >= 0 && index < input.Length;
        }
    }
}
