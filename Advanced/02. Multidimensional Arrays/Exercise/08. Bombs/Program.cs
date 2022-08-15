using System;
using System.Linq;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = elements[col];
                }
            }

            int[] bombs = Console.ReadLine()
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bombs.Length; i+=2)
            {
                int row = bombs[i];
                int col = bombs[i + 1];

                int bombPower = matrix[row,col];

                if (bombPower <= 0)
                {
                    continue;
                }
                // Upper 3 
                if (IsInMatrix(matrix,row - 1,col -1) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= bombPower;
                }
                if (IsInMatrix(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= bombPower;
                }
                if (IsInMatrix(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= bombPower;
                }
                // Same row left and right
                if (IsInMatrix(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= bombPower;
                }
                if (IsInMatrix(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= bombPower;
                }
                // Lower 3 
                if (IsInMatrix(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= bombPower;
                }
                if (IsInMatrix(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= bombPower;
                }
                if (IsInMatrix(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= bombPower;
                }

                matrix[row, col] = 0;
            }

            int aliveCells = 0;
            int sum = 0;

            foreach (var num in matrix)
            {
                if (num > 0)
                {
                    aliveCells++;
                    sum += num;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInMatrix(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
