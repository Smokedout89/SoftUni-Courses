using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                int sum = 0;

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    sum += matrix[r, c];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
