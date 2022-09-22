using System;
using System.Text;

namespace Pawn_Wars
{
    internal class PawnWars
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            bool whiteWon = false;
            bool blackWon = false;
            string coordinates = string.Empty;

            while (true)
            {
                if (whiteRow == 0)
                {
                    coordinates = GetCoordinates(matrix, whiteRow, whiteCol);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                    break;
                }

                if (MoveWhite(matrix, whiteRow, whiteCol, whiteWon))
                {
                    coordinates = GetCoordinates(matrix, blackRow, blackCol);
                    Console.WriteLine($"Game over! White capture on {coordinates}.");
                    break;
                }
                else
                {
                    matrix[whiteRow, whiteCol] = '-';
                    whiteRow -= 1;
                    matrix[whiteRow, whiteCol] = 'w';
                }

                if (blackRow == 7)
                {
                    coordinates = GetCoordinates(matrix, blackRow, blackCol);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                    break;
                }

                if (MoveBlack(matrix, blackRow, blackCol, blackWon))
                {
                    coordinates = GetCoordinates(matrix, whiteRow, whiteCol);
                    Console.WriteLine($"Game over! Black capture on {coordinates}.");
                    break;
                }
                else
                {
                    matrix[blackRow, blackCol] = '-';
                    blackRow += 1;
                    matrix[blackRow, blackCol] = 'b';
                }
            }
        }

        private static bool MoveBlack(char[,] matrix, int blackRow, int blackCol, bool blackWon)
        {
            if (IsInMatrix(matrix, blackRow + 1, blackCol + 1) && matrix[blackRow + 1, blackCol + 1] == 'w')
            {
                return true;
            }

            if (IsInMatrix(matrix, blackRow + 1, blackCol - 1) && matrix[blackRow + 1, blackCol - 1] == 'w')
            {
                return true;
            }

            return false;
        }

        private static bool MoveWhite(char[,] matrix, int whiteRow, int whiteCol, bool whiteWon)
        {
            if (IsInMatrix(matrix, whiteRow - 1, whiteCol - 1) && matrix[whiteRow - 1, whiteCol - 1] == 'b')
            {
                return true;
            }

            if (IsInMatrix(matrix, whiteRow - 1, whiteCol + 1) && matrix[whiteRow - 1, whiteCol + 1] == 'b')
            {
                return true;
            }

            return false;
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < 8 && col < 8;
        }

        private static string GetCoordinates(char[,] matrix, int whiteRow, int whiteCol)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                if (i == whiteCol)
                {
                    sb.Append((char)(i + 97));
                    break;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (i == whiteRow)
                {
                    switch (i)
                    {
                        case 0: i = 8; break;
                        case 1: i = 7; break;
                        case 2: i = 6; break;
                        case 3: i = 5; break;
                        case 4: i = 4; break;
                        case 5: i = 3; break;
                        case 6: i = 2; break;
                        case 7: i = 1; break;
                    }

                    sb.Append(i);
                    break;
                }
            }

            return sb.ToString();
        }
    }
}
