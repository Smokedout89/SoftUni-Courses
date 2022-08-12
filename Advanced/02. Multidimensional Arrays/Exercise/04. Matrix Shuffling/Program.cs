using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[rowCols[0], rowCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command.StartsWith("swap") && cmdArgs.Length == 5)
                {
                    int firstRow = int.Parse(cmdArgs[1]);
                    int firstCol = int.Parse(cmdArgs[2]);
                    int secondRow = int.Parse(cmdArgs[3]);
                    int secondCol = int.Parse(cmdArgs[4]);

                    if (ValidateRows(matrix,firstRow) && ValidateRows(matrix,secondRow)
                        && ValidateCols(matrix, firstCol) && ValidateCols(matrix, secondCol))
                    {
                        string firstItem = matrix[firstRow, firstCol];
                        string secondItem = matrix[secondRow, secondCol];

                        matrix[firstRow, firstCol] = secondItem;
                        matrix[secondRow, secondCol] = firstItem;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }
        static bool ValidateRows(string[,] matrix, int index)
        {
            return index >= 0 && index < matrix.GetLength(0);
        }

        static bool ValidateCols(string[,] matrix, int index)
        {
            return index >= 0 && index < matrix.GetLength(1);
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
