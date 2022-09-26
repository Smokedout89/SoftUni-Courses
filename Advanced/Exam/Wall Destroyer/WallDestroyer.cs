using System;

namespace Wall_Destroyer
{
    internal class WallDestroyer
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int vankoRow = 0;
            int vankoCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            string command;
            int holesDigged = 0;
            int rodsHit = 0;
            bool hitCable = false;
            bool firstHole = false;

            while ((command = Console.ReadLine()) != "End")
            {
                if (!firstHole)
                {
                    holesDigged++;
                    firstHole = true;
                }

                string direction = command;
                int nextRow = 0;
                int nextCol = 0;

                switch (direction)
                {
                    case "up": nextRow = -1; break;
                    case "down": nextRow = 1; break;
                    case "left": nextCol = -1; break;
                    case "right": nextCol = 1; break;
                }

                if (!IsInMatrix(matrix, vankoRow + nextRow, vankoCol + nextCol))
                {
                    continue;
                }

                if (matrix[vankoRow + nextRow, vankoCol + nextCol] == 'C')
                {
                    matrix[vankoRow + nextRow, vankoCol + nextCol] = 'E';
                    matrix[vankoRow, vankoCol] = '*';
                    holesDigged++;
                    hitCable = true;
                    break;
                }

                if (matrix[vankoRow + nextRow, vankoCol + nextCol] == 'R')
                {
                    rodsHit++;
                    Console.WriteLine("Vanko hit a rod!");
                    continue;
                }

                matrix[vankoRow, vankoCol] = '*';
                vankoRow += nextRow;
                vankoCol += nextCol;

                if (matrix[vankoRow, vankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    continue;
                }

                holesDigged++;
            }

            if (hitCable)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesDigged} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesDigged} hole(s) and he hit only {rodsHit} rod(s).");
                matrix[vankoRow, vankoCol] = 'V';
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(0);
        }
    }
}
