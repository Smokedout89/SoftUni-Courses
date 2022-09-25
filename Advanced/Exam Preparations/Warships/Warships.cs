using System;

namespace Warships
{
    internal class Warships
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] attackCoordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[n, n];

            int playerOneShips = 0;
            int playerTwoShips = 0;
            int destroyedShips = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            for (int i = 0; i < attackCoordinates.Length; i ++)
            {
                string[] currAttack = attackCoordinates[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int attackRow = int.Parse(currAttack[0]);
                int attackCol = int.Parse(currAttack[1]);

                if (!IsInMatrix(matrix, attackRow, attackCol))
                {
                    continue;
                }

                if (matrix[attackRow, attackCol] == '#')
                {
                    matrix[attackRow, attackCol] = 'X';

                    if (IsInMatrix(matrix, attackRow - 1, attackCol - 1))
                    {
                        if (matrix[attackRow - 1, attackCol - 1] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow - 1, attackCol - 1] = 'X';
                        }
                        else if (matrix[attackRow - 1, attackCol - 1] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow - 1, attackCol - 1] = 'X';
                        }
                    }

                    if (IsInMatrix(matrix, attackRow - 1, attackCol))
                    {
                        if (matrix[attackRow - 1, attackCol] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow - 1, attackCol] = 'X';
                        }
                        else if (matrix[attackRow - 1, attackCol] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow - 1, attackCol] = 'X';
                        }
                    }

                    if (IsInMatrix(matrix, attackRow - 1, attackCol + 1))
                    {
                        if (matrix[attackRow - 1, attackCol + 1] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow - 1, attackCol + 1] = 'X';
                        }
                        else if (matrix[attackRow - 1, attackCol + 1] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow - 1, attackCol + 1] = 'X';
                        }
                    }

                    if (IsInMatrix(matrix, attackRow, attackCol - 1))
                    {
                        if (matrix[attackRow, attackCol - 1] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow, attackCol - 1] = 'X';
                        }
                        else if (matrix[attackRow, attackCol - 1] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow, attackCol - 1] = 'X';
                        }
                    }

                    if (IsInMatrix(matrix, attackRow, attackCol + 1))
                    {
                        if (matrix[attackRow, attackCol + 1] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow, attackCol + 1] = 'X';
                        }
                        else if (matrix[attackRow, attackCol + 1] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow, attackCol + 1] = 'X';
                        }
                    }

                    if (IsInMatrix(matrix, attackRow + 1, attackCol - 1))
                    {
                        if (matrix[attackRow + 1, attackCol - 1] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow + 1, attackCol - 1] = 'X';
                        }
                        else if (matrix[attackRow + 1, attackCol - 1] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow + 1, attackCol - 1] = 'X';
                        }
                    }

                    if (IsInMatrix(matrix, attackRow + 1, attackCol))
                    {
                        if (matrix[attackRow + 1, attackCol] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        else if (matrix[attackRow + 1, attackCol] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                    }

                    if (IsInMatrix(matrix, attackRow + 1, attackCol + 1))
                    {
                        if (matrix[attackRow + 1, attackCol + 1] == '<')
                        {
                            playerOneShips--;
                            destroyedShips++;
                            matrix[attackRow + 1, attackCol + 1] = 'X';
                        }
                        else if (matrix[attackRow + 1, attackCol + 1] == '>')
                        {
                            playerTwoShips--;
                            destroyedShips++;
                            matrix[attackRow + 1, attackCol + 1] = 'X';
                        }
                    }
                }
                else if (matrix[attackRow, attackCol] == '<')
                {
                    playerOneShips--;
                    destroyedShips++;
                    matrix[attackRow, attackCol] = 'X';
                }
                else if (matrix[attackRow, attackCol] == '>')
                {
                    playerTwoShips--;
                    destroyedShips++;
                    matrix[attackRow, attackCol] = 'X';
                }

                if (playerOneShips == 0 || playerTwoShips == 0)
                {
                    break;
                }
            }

            if (playerOneShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else if (playerTwoShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
