using System;
using System.Linq;

namespace Truffle_Hunter
{
    internal class TruffleHunter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] element = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = element[col];
                }
            }

            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int boarEaten = 0;

            string command;

            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (action == "Collect")
                {
                    if (matrix[row, col] == 'B')
                    {
                        blackTruffle++;
                        matrix[row, col] = '-';
                    }
                    else if (matrix[row, col] == 'S')
                    {
                        summerTruffle++;
                        matrix[row, col] = '-';
                    }
                    else if (matrix[row, col] == 'W')
                    {
                        whiteTruffle++;
                        matrix[row, col] = '-';
                    }
                }
                else if (action == "Wild_Boar")
                {
                    string direction = cmdArgs[3];
                    boarEaten = MoveBoar(direction, matrix, row, col, boarEaten);
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffle} black, {summerTruffle} summer, and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarEaten} truffles.");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static int MoveBoar(string direction, char[,] matrix, int row, int col, int boarEaten)
        {
            while (IsInMatrix(matrix, row, col))
            {
                if (matrix[row, col] == 'B' || matrix[row, col] == 'S' || matrix[row, col] == 'W')
                {
                    boarEaten++;
                    matrix[row, col] = '-';
                }

                switch (direction)
                {
                    case "up": row -= 2; break;
                    case "down": row += 2; break;
                    case "left": col -= 2; break;
                    case "right": col += 2; break;
                }
            }

            return boarEaten;
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
