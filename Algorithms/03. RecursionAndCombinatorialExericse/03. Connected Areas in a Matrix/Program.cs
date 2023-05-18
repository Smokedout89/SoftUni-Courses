namespace _03.Connected_Areas_in_a_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static char[,] matrix;
        private static int size;
        private const char VisitedSymbol = 'v';

        public class Area
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Size { get; set; }
        }

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string elements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = elements[c];
                }
            }

            var areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    size = 0;
                    ExploreArea(r, c);

                    if (size > 0)
                    {
                        areas.Add(new Area { Row = r, Col = c, Size = size });
                    }
                }
            }

            var sorted = areas
                .OrderByDescending(s => s.Size)
                .ThenBy(r => r.Row)
                .ThenBy(c => c.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                var area = sorted[i];
                Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size += 1;
            matrix[row, col] = VisitedSymbol;

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VisitedSymbol;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        }
    }
}
