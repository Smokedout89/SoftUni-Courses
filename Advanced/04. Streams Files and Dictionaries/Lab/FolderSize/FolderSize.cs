namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);
            double sum = 0;

            foreach (FileInfo file in infos)  
            {
                sum += file.Length;
            }
            sum = (sum / 1024) / 1024;
            File.WriteAllText(outputFilePath, sum.ToString());
        }
    }
}
