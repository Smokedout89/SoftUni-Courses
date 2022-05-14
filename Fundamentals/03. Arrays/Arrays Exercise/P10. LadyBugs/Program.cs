using System;
using System.Linq;

namespace P10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugIndexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < field.Length; i++)
            {
                if (ladybugIndexes.Contains(i))
                {
                    field[i] = 1;
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArguments = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                int initialIndex = (int.Parse(commandArguments[0]));
                string direction = commandArguments[1];
                int flyLength = int.Parse(commandArguments[2]);

                if (initialIndex < 0 || initialIndex >= field.Length)
                {
                    continue;    // Check if index is inside the field, if not nothing happen, skips the command
                }

                if (field[initialIndex] == 0)
                {
                    continue;  // Check if there is a bug at this index, if not nothing happen, skips the command
                }

                field[initialIndex] = 0;   // The bug start flying, its index goes to 0
                int nextIndex = initialIndex;  // initialize next index 

                while (true)
                {
                    if (direction == "right")
                    {
                        nextIndex += flyLength; // calculate next index
                    }
                    else if (direction == "left")
                    {
                        nextIndex -= flyLength; // calculate next index
                    }

                    if (nextIndex < 0 || nextIndex >= field.Length)
                    {
                        break; // Check if next index is valid, if not ladybug is gone into the void
                    }

                    if (field[nextIndex] == 0)
                    {
                        break; // Check if index is free to land or there is another ladybug there
                               // If there is already bug, we break, and repeat the same flylength
                    }
                }

                if (nextIndex >= 0 && nextIndex < field.Length)
                {
                    field[nextIndex] = 1;
                }

            }

            Console.WriteLine(String.Join(' ', field));
        }
    }
}
