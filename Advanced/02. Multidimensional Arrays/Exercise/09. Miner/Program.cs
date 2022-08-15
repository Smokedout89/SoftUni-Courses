using System;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();

            char[,] matrix = new char[n, n];

            int coalCount = 0;
            int minerRow = 0;
            int minerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {   
                string[] elements = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col][0];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            foreach (var direction in directions)
            {
                int nextRow = 0;
                int nextCol = 0;

                switch (direction)
                {
                    case "up": nextRow = -1; break;
                    case "down": nextRow = 1; break;
                    case "left": nextCol = -1; break;
                    case "right": nextCol = 1; break;
                }

                if (!IsInMatrix(matrix, minerRow + nextRow, minerCol + nextCol))
                {
                    continue;
                }

                minerRow += nextRow;
                minerCol += nextCol;

                if (matrix[minerRow,minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    Environment.Exit(0);
                }

                if (matrix[minerRow, minerCol] == 'c')
                {
                    matrix[minerRow, minerCol] = '*';
                    coalCount--;

                    if (coalCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({minerRow}, {minerCol})");
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
