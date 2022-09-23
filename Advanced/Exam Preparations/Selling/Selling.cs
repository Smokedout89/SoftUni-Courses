using System;
using System.Collections.Generic;

namespace Selling
{
    internal class Selling
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            List<int[]> pillars = new List<int[]>();
            List<int[]> customers = new List<int[]>();

            int dollars = 0;
            bool outOfBakery = false;
            bool enoughMoney = false;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (matrix[row, col] == 'O')
                    {
                        pillars.Add(new[] { row, col });
                    }

                    if (char.IsDigit(matrix[row, col]))
                    {
                        customers.Add(new[] { row, col });
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                int nextRow = 0;
                int nextCol = 0;

                switch (command)
                {
                    case "up": nextRow = -1; break;
                    case "down": nextRow = 1; break;
                    case "left": nextCol = -1; break;
                    case "right": nextCol = 1; break;
                }

                matrix[playerRow, playerCol] = '-';

                if (!IsInMatrix(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    outOfBakery = true;
                    break;
                }
                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;
                }

                if (matrix[playerRow, playerCol] == 'O')
                {
                    foreach (var pillar in pillars)
                    {
                        if (matrix[playerRow, playerCol] == matrix[pillar[0], pillar[1]])
                        {
                            matrix[pillar[0], pillar[1]] = '-';
                            continue;
                        }
                        else
                        {
                            playerRow = pillar[0];
                            playerCol = pillar[1];
                        }
                    }
                }

                if (char.IsDigit(matrix[playerRow, playerCol]))
                {
                    dollars += int.Parse(matrix[playerRow, playerCol].ToString());
                    matrix[playerRow, playerCol] = 'S';

                    if (dollars >= 50)
                    {
                        enoughMoney = true;
                        break;
                    }
                }
            }

            if (outOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            if (enoughMoney)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {dollars}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
