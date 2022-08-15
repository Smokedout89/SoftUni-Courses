using System;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int knightsToRemove = 0;

            while (true)
            {
                int maxAttacked = 0;
                int knighToRemoveRow = 0;
                int knightToRemoveCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }

                        int currentAttacks = 0;
                        // Up left and right
                        if (IsInRange(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        // Down right and left
                        if (IsInRange(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        // Left up and down
                        if (IsInRange(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        // Right up and down
                        if (IsInRange(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (currentAttacks > maxAttacked)
                        {
                            maxAttacked = currentAttacks;
                            knighToRemoveRow = row;
                            knightToRemoveCol = col;
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    knightsToRemove++;
                    matrix[knighToRemoveRow, knightToRemoveCol] = '0';
                }
                else
                {
                    Console.WriteLine(knightsToRemove);
                    break;
                }
            }

        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
