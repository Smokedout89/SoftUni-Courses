
namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> mergedList = new List<string>();

            string[] firstFileLines = File.ReadAllLines(firstInputFilePath);
            string[] secondFileLines = File.ReadAllLines(secondInputFilePath);

            foreach (string line in firstFileLines)
            {
                mergedList.Add(line);
            }

            foreach (string line in secondFileLines)
            {
                mergedList.Add(line);
            }

            File.WriteAllLines(outputFilePath, mergedList.OrderBy(x => x));
        }
    }
}
