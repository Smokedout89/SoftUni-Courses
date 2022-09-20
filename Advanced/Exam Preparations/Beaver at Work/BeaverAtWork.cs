using System;
using System.Linq;
using System.Collections.Generic;

namespace Beaver_at_Work
{
    internal class BeaverAtWork
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int beaverRow = 0;
            int beaverCol = 0;
            int branchesInPond = 0;
            int removedBranches = 0;
            int branchesColected = 0;
            List<char> branches = new List<char>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    if (char.IsLower(matrix[row, col]))
                    {
                        branchesInPond++;
                    }
                }
            }

            string command;
            bool collectedAll = false;

            while ((command = Console.ReadLine()) != "end")
            {
                if (collectedAll)
                {
                    break;
                }

                int nextRow = 0;
                int nextCol = 0;

                switch (command)
                {
                    case "up": nextRow = -1; break;
                    case "down": nextRow = 1; break;
                    case "left": nextCol = -1; break;
                    case "right": nextCol = 1; break;
                }

                if (!IsInMatrix(matrix, beaverRow + nextRow, beaverCol + nextCol))
                {
                    if (branches.Count > 0)
                    {
                        branches.RemoveAt(branches.Count - 1);
                        branchesColected--;
                        removedBranches++;
                    }
                    continue;
                }

                matrix[beaverRow, beaverCol] = '-';
                beaverRow += nextRow;
                beaverCol += nextCol;

                if (char.IsLower(matrix[beaverRow, beaverCol]))
                {
                    branches.Add(matrix[beaverRow, beaverCol]);
                    branchesColected++;
                }

                if (matrix[beaverRow, beaverCol] == 'F')
                {
                    matrix[beaverRow, beaverCol] = '-';

                    if (command == "up")
                    {
                        if (beaverRow != 0)
                        {
                            beaverRow = 0;
                        }
                        else
                        {
                            beaverRow = n - 1;
                        }
                    }
                    if (command == "down")
                    {
                        if (beaverRow != n - 1)
                        {
                            beaverRow = n - 1;
                        }
                        else
                        {
                            beaverRow = 0;
                        }
                    }
                    if (command == "left")
                    {
                        if (beaverCol != 0)
                        {
                            beaverCol = 0;
                        }
                        else
                        {
                            beaverCol = n - 1;
                        }
                    }
                    if (command == "right")
                    {
                        if (beaverCol != n - 1)
                        {
                            beaverCol = n - 1;
                        }
                        else
                        {
                            beaverCol = 0;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branches.Add(matrix[beaverRow, beaverCol]);
                        branchesColected++;
                    }
                }

                if (branchesColected + removedBranches == branchesInPond)
                {
                    collectedAll = true;
                }

                matrix[beaverRow, beaverCol] = 'B';
            }

            if (collectedAll)
            {
                Console.WriteLine($"The Beaver successfully collect {branchesColected} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesInPond - branchesColected - removedBranches} branches left.");
            }

            PrintMatrix(matrix);
        }

        static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col > 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
