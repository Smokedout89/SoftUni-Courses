using System;

namespace Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int playerRow = 0;
            int playerCol = 0;
            bool reachedExit = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                if (reachedExit)
                {
                    break;
                }
                string direction = Console.ReadLine();
                (playerRow, playerCol, reachedExit) = MovePlayer(matrix, playerRow, playerCol, direction, reachedExit);
            }

            if (reachedExit)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
        }

        private static (int row, int col, bool reachedExit) MovePlayer(char[,] matrix, int playerRow, int playerCol, string direction, bool reachedExit)
        {
            int rowBeforeMove = playerRow;
            int colBeforeMove = playerCol;
            matrix[playerRow, playerCol] = '-';

            switch (direction)
            {
                case "up": playerRow -= 1; break;
                case "down": playerRow += 1; break;
                case "left": playerCol -= 1; break;
                case "right": playerCol += 1; break;
            }

            if (!IsInMatrix(matrix, playerRow, playerCol))
            {
               (playerRow, playerCol) = ChangePosition(matrix, playerRow, playerCol);
            }

            if (matrix[playerRow, playerCol] == 'T')
            {
                playerRow = rowBeforeMove;
                playerCol = colBeforeMove;
            }

            if (matrix[playerRow, playerCol] == 'B')
            {
                switch (direction)
                {
                    case "up": playerRow -= 1; break;
                    case "down": playerRow += 1; break;
                    case "left": playerCol -= 1; break;
                    case "right": playerCol += 1; break;
                }
            }

            if (!IsInMatrix(matrix, playerRow, playerCol))
            {
                (playerRow, playerCol) = ChangePosition(matrix, playerRow, playerCol);
            }

            if (matrix[playerRow, playerCol] == 'F')
            {
                reachedExit = true;
            }

            matrix[playerRow, playerCol] = 'f';
            return (playerRow, playerCol, reachedExit);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static (int row, int col) ChangePosition(char[,] matrix, int row, int col)
        {
            if (row < 0)
            {
                row = matrix.GetLength(0) - 1;
            }

            if (row >= matrix.GetLength(0))
            {
                row = 0;
            }

            if (col < 0)
            {
                col = matrix.GetLength(1) - 1;
            }

            if (col >= matrix.GetLength(1))
            {
                col = 0;
            }

            return (row, col);
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
