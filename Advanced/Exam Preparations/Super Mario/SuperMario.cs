using System;

namespace Super_Mario
{
    internal class SuperMario
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int matrixRows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[matrixRows][];

            int marioRow = 0;
            int marioCol = 0;
            bool reachedPrinces = false;
            bool hasDied = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                if (hasDied || reachedPrinces)
                {
                    break;
                }

                string[] turn = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = turn[0];
                int bowserRow = int.Parse(turn[1]);
                int bowserCol = int.Parse(turn[2]);

                matrix[bowserRow][bowserCol] = 'B';

                int nextRow = 0;
                int nextCol = 0;

                switch (direction)
                {
                    case "W": nextRow = -1; break;
                    case "S": nextRow = 1; break;
                    case "A": nextCol = -1; break;
                    case "D": nextCol = 1; break;
                }

                lives--;

                if (!IsInMatrix(matrix, marioRow + nextRow, marioCol + nextCol))
                {
                    continue;
                }

                matrix[marioRow][marioCol] = '-';
                marioRow += nextRow;
                marioCol += nextCol;

                if (matrix[marioRow][marioCol] == 'B')
                {
                    lives -= 2;

                    if (lives <= 0)
                    {
                        hasDied = true;
                        matrix[marioRow][marioCol] = 'X';
                        continue;
                    }

                    matrix[marioRow][marioCol] = 'M';
                }

                if (matrix[marioRow][marioCol] == 'P')
                {
                    matrix[marioRow][marioCol] = '-';
                    reachedPrinces = true;
                    continue;
                }

                if (lives <= 0)
                {
                    hasDied = true;
                    matrix[marioRow][marioCol] = 'X';
                }
            }

            if (hasDied)
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            if (reachedPrinces)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            foreach (var row in matrix)        
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        static bool IsInMatrix(char[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix[row].Length;
        }
    }
}
