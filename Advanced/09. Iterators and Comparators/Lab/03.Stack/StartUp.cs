using System;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            CustomStack<string> stack = new CustomStack<string>();

            while (command != "END")
            {
                string[] cmdArgs = command.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Push")
                {
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        stack.Push(cmdArgs[i]);
                    }
                }
                else if (cmdArgs[0] == "Pop")
                {
                    stack.Pop();
                }

                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
