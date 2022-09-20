using System;

namespace Armory
{
    internal class Armory
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            int officerRow = 0;
            int officerCol = 0;
            int coins = 0;
            bool leftArmory = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }

            while (coins < 65 && !leftArmory)
            {
                string direction = Console.ReadLine();
                int nextRow = 0;
                int nextCol = 0;

                switch (direction)
                {
                    case "up": nextRow = -1; break;
                    case "down": nextRow = 1; break;
                    case "left": nextCol = -1; break;
                    case "right": nextCol = 1; break;
                }

                if (!IsInMatrix(matrix, officerRow + nextRow, officerCol + nextCol))
                {
                    leftArmory = true;
                    matrix[officerRow, officerCol] = '-';
                    break;
                }

                matrix[officerRow, officerCol] = '-';
                officerRow += nextRow;
                officerCol += nextCol;

                if (char.IsDigit(matrix[officerRow, officerCol]))
                {
                    coins += matrix[officerRow, officerCol] - '0';
                    matrix[officerRow, officerCol] = 'A';
                }

                if (matrix[officerRow, officerCol] == 'M')
                {
                   (officerRow, officerCol) = MoveToAnotherMirror(matrix, officerRow, officerCol);
                }
            }

            if (leftArmory)
            {
                Console.WriteLine($"I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {coins} gold coins.");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static (int row, int col) MoveToAnotherMirror(char[,] matrix, int officerRow, int officerCol)
        {
            matrix[officerRow, officerCol] = '-';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }

            matrix[officerRow, officerCol] = 'A';
            return (officerRow, officerCol);
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
