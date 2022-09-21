using System;
using System.Linq;
using System.Collections.Generic;

namespace Garden
{
    internal class Garden
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            string command;
            List<int[]> plantCoordinates = new List<int[]>();

            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] plant = command.Split().Select(int.Parse).ToArray();
                int row = plant[0];
                int col = plant[1];

                if (!IsInMatrix(matrix, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                matrix[row, col]++;
                plantCoordinates.Add(plant);
            }

            foreach (var plant in plantCoordinates)
            {
                Bloom(matrix, plant[0], plant[1]);
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void Bloom(int[,] matrix, int row, int col)
        {
            BloomUp(matrix, row, col);
            BloomDown(matrix, row, col);
            BloomLeft(matrix, row, col);
            BloomRight(matrix, row, col);
        }

        private static void BloomDown(int[,] matrix, int row, int col)
        {
            row += 1;

            while (IsInMatrix(matrix, row, col))
            {
                matrix[row, col]++;
                row++;
            }
        }

        private static void BloomUp(int[,] matrix, int row, int col)
        {
            row -= 1;

            while (IsInMatrix(matrix, row, col))
            {
                matrix[row, col]++;
                row--;
            }
        }

        private static void BloomRight(int[,] matrix, int row, int col)
        {
            col += 1;

            while (IsInMatrix(matrix, row, col))
            {
                matrix[row, col]++;
                col++;
            }
        }

        private static void BloomLeft(int[,] matrix, int row, int col)
        {
            col -= 1;

            while (IsInMatrix(matrix, row, col))
            {
                matrix[row, col]++;
                col--;
            }
        }

        private static bool IsInMatrix(int[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
