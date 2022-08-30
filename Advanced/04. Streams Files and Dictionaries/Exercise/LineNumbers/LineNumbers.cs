    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilepath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilepath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 1;
            List<string> modifiedLines = new List<string>();

            foreach (var line in lines)
            {
                int letterCount = line.Count(char.IsLetter);
                int punctionCount = line.Count(char.IsPunctuation);

                string modifiedLine = $"Line {count}: {line} ({letterCount})({punctionCount})";
                modifiedLines.Add(modifiedLine);
                count++;
            }

            File.WriteAllLines(outputFilePath, modifiedLines);
        }
    }
}