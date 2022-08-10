using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = ReadArrayFromConsole();
            }

            string command = Console.ReadLine().ToUpper();

            while (command != "END")
            {
                string[] tokens = command.Split(' ');
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 || row >= n || col < 0 || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine().ToUpper();
                    continue;
                }

                switch (tokens[0])  
                {
                    case "ADD":
                        jagged[row][col] += value;
                        break;
                    case "SUBTRACT":
                        jagged[row][col] -= value;
                        break;
                }

                command = Console.ReadLine().ToUpper();
            }

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(string.Join(' ', jagged[i]));
            //}

            foreach (int[] row in jagged)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
