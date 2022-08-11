using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = elements[col];
                }
            }

            int leftSum = 0;
            int rightSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                leftSum += matrix[row, row];
                rightSum += matrix[row, matrix.GetLength(0) - 1 - row];
            }

            int result = Math.Abs(leftSum - rightSum);
            Console.WriteLine(result);
        }
        
    }
}
