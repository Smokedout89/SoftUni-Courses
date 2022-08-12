using System;
using System.Linq;

namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[rowCols[0], rowCols[1]];

            string snake = Console.ReadLine();
            
            bool leftToRight = true;
            int indexOfSnake = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (leftToRight)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[indexOfSnake++];

                        if (indexOfSnake == snake.Length)
                        {
                            indexOfSnake = 0;
                        }
                    }

                    leftToRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row,col] = snake[indexOfSnake++];

                        if (indexOfSnake == snake.Length)
                        {
                            indexOfSnake = 0;
                        }
                    }

                    leftToRight = true;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
