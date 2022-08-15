using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool hasWon = false;
            bool isDead = false;

            foreach (var direction in directions)
            {
                int nextRow = 0;
                int nextCol = 0;

                switch (direction)
                {
                    case 'R': nextCol = 1; break;
                    case 'L': nextCol = -1; break;
                    case 'U': nextRow = -1; break;
                    case 'D': nextRow = 1; break;
                }

                matrix[playerRow, playerCol] = '.';

                if (!IsInMatrix(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    hasWon = true;
                }
                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;
                }


                if (matrix[playerRow, playerCol] == 'B')
                {
                    isDead = true;
                }
                else if (!hasWon)
                {
                    matrix[playerRow, playerCol] = 'P';
                }

                List<int[]> bunnies = new List<int[]>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunnies.Add(new[] { row, col });
                        }
                    }
                }

                foreach (var bunny in bunnies)
                {
                    int bunnyRow = bunny[0];
                    int bunnyCol = bunny[1];

                    if (IsInMatrix(matrix, bunnyRow - 1, bunnyCol))
                    {
                        if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[bunnyRow - 1, bunnyCol] = 'B';
                    }

                    if (IsInMatrix(matrix, bunnyRow + 1, bunnyCol))
                    {
                        if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[bunnyRow + 1, bunnyCol] = 'B';
                    }

                    if (IsInMatrix(matrix, bunnyRow, bunnyCol + 1))
                    {
                        if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[bunnyRow, bunnyCol + 1] = 'B';
                    }

                    if (IsInMatrix(matrix, bunnyRow, bunnyCol - 1))
                    {
                        if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[bunnyRow, bunnyCol - 1] = 'B';
                    }
                }

                if (hasWon || isDead)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row,col]);
                        }

                        Console.WriteLine();
                    }
                }

                if (hasWon)
                {
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
                else if (isDead)
                {
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }

        }
        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
