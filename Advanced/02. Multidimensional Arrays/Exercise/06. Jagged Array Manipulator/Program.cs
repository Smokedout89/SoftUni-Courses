using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(el => el * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(el => el / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el / 2).ToArray();
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split();

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (command.StartsWith("Add"))
                {
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                }

                if (command.StartsWith("Subtract"))
                {
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (int[] intRows in matrix)
            {
                Console.WriteLine(string.Join(' ', intRows));
            }
        }
    }
}
