using System;

namespace The_Battle_of_the_Five_Armies
{
    internal class TheBattleoftheFiveArmies
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int matrixRows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixRows][];
            int armyRow = 0;
            int armyCol = 0;
            bool reachedMordor = false;
            bool hasDied = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (armyArmor > 0 && !reachedMordor && !hasDied)
            {
                string[] command = Console.ReadLine().Split();
                string direction = command[0];
                int orcsRow = int.Parse(command[1]);
                int orcsCol = int.Parse(command[2]);

                matrix[orcsRow][orcsCol] = 'O';

                (armyRow, armyCol, armyArmor) = MoveArmy(matrix, armyRow, armyCol, direction, armyArmor);

                if (matrix[armyRow][armyCol] == 'O')
                {
                    armyArmor -= 2;
                }

                if (matrix[armyRow][armyCol] == 'M')
                {
                    matrix[armyRow][armyCol] = '-';
                    reachedMordor = true;
                    break;
                }

                if (armyArmor <= 0)
                {
                    hasDied = true;
                    matrix[armyRow][armyCol] = 'X';
                }
                else
                {
                    matrix[armyRow][armyCol] = 'A';
                }
            }

            if (reachedMordor)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static (int row, int col, int armor) MoveArmy(char[][] matrix, int armyRow, int armyCol, string direction, int armyArmor)
        {
            int nextRow = 0;
            int nextCol = 0;

            switch (direction)
            {
                case "up": nextRow = -1; break;
                case "down": nextRow = 1; break;
                case "left": nextCol = -1; break;
                case "right": nextCol = 1; break;
            }

            armyArmor--;

            if (!IsInMatrix(matrix, armyRow + nextRow, armyCol + nextCol))
            {
                return (armyRow, armyCol, armyArmor);
            }

            matrix[armyRow][armyCol] = '-';
            armyRow += nextRow;
            armyCol += nextCol;
            return (armyRow, armyCol, armyArmor);
        }

        private static bool IsInMatrix(char[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix[row].Length;
        }
    }
}
