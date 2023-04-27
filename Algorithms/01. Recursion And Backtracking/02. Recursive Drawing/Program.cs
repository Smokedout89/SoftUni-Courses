namespace _02.Recursive_Drawing
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            DrawFigure(n);
        }

        private static void DrawFigure(int row)
        {
            if (row == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', row));

            DrawFigure(row - 1);

            Console.WriteLine(new string('#', row));
        }
    }
}
