using System;

namespace Survivor
{
    internal class Survivor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }

            string command;
            int myTokens = 0;
            int enemyTokens = 0;

            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (action == "Find")
                {
                    if (!IsInMatrix(matrix, row, col))
                    {
                        continue;
                    }

                    if (matrix[row][col] == 'T')
                    {
                        myTokens++;
                        matrix[row][col] = '-';
                    }
                }
                else if (action == "Opponent")
                {
                    string direction = cmdArgs[3];

                    if (!IsInMatrix(matrix, row, col))
                    {
                        continue;
                    }

                    if (matrix[row][col] == 'T')
                    {
                        enemyTokens++;
                        matrix[row][col] = '-';
                    }

                    enemyTokens = MoveEnemy(matrix, row, col, direction, enemyTokens);
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");
        }

        private static int MoveEnemy(char[][] matrix, int row, int col, string direction, int enemyTokens)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (direction)
                {
                    case "up": row -= 1; break;
                    case "down": row += 1; break;
                    case "left": col -= 1; break;
                    case "right": col += 1; break;
                }

                if (!IsInMatrix(matrix, row, col))
                {
                    return enemyTokens;
                }
                
                if (matrix[row][col] == 'T')
                {
                    enemyTokens++;
                    matrix[row][col] = '-';
                }
            }

            return enemyTokens;
        }

        private static bool IsInMatrix(char[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix[row].Length;
        }
    }
}
