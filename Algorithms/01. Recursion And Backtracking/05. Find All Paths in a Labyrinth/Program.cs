namespace _05.Find_All_Paths_in_a_Labyrinth
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string element = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = element[col];
                }
            }

            FindPaths(labyrinth, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] labyrinth, int row, int col, List<string> directions, string direction)
        {
            // Validate row and col
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            // Check for walls or visited
            if (labyrinth[row, col] == '*' || labyrinth[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            // Check for exit
            if (labyrinth[row, col] == 'e') 
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            labyrinth[row, col] = 'v';
            
            FindPaths(labyrinth, row - 1, col, directions, "U");    // UP
            FindPaths(labyrinth, row + 1, col, directions, "D");    // DOWN
            FindPaths(labyrinth, row, col - 1, directions, "L");    // LEFT
            FindPaths(labyrinth, row, col + 1, directions, "R");    // RIGHT

            labyrinth[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
