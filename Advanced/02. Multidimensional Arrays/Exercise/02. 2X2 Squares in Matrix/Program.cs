using System;
using System.Linq;

namespace _02._2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[rowCols[0], rowCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = elements[col];
                }
            }

            int equalSquareCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row,col] == matrix[row, col+1] 
                        && matrix[row,col] == matrix[row+1,col]
                        && matrix[row, col] == matrix[row+1, col+1])
                    {
                        equalSquareCount++;
                    }
                }
            }

            Console.WriteLine(equalSquareCount);
        }
    }
}
