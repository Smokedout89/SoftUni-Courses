using System;
using System.Linq;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] cmdArgs = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string commandType = cmdArgs[0];

                if (commandType == "InsertSpace")
                {
                    int indexToInsert = int.Parse(cmdArgs[1]);
                    message = message.Insert(indexToInsert, " ");

                    Console.WriteLine(message);
                }
                else if (commandType == "Reverse")
                {
                    string substring = cmdArgs[1];
                    if (message.Contains(substring))
                    {
                        int startIndex = message.IndexOf(substring);
                        message = message.Remove(startIndex, substring.Length);
                        char[] reversed = substring.Reverse().ToArray();
                        message += string.Join("", reversed);

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commandType == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
