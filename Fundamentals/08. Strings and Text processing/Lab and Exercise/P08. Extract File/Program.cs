using System;

namespace P08._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int lastIndex = input.LastIndexOf("\\");
            int extensionIndex = input.IndexOf('.');

            int fileLenght = extensionIndex - lastIndex - 1;

            string fileName = input.Substring(lastIndex + 1, fileLenght);
            string extensionName = input.Substring(extensionIndex + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extensionName}");
        }
    }
}
