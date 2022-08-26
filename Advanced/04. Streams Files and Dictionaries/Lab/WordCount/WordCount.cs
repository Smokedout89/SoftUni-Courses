namespace WordCount
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            //string outputPath = @"..\..\..\Files\output.txt";
            //string textPath = @"..\..\..\Files\text.txt";
            //string wordsPath = @"..\..\..\Files\words.txt";

            string[] textLines = File.ReadAllLines(textFilePath);
            string[] words = File.ReadAllText(wordsFilePath).Split().ToArray();

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }

            foreach (string line in textLines)
            {
                string[] currentLine = line.Split(new char[] { ' ', '.', ',', '!', '?', '-', '\'' });

                foreach (string currentWord in currentLine)
                {
                    string lowercaseWord = currentWord.ToLower();

                    if (wordsCount.ContainsKey(lowercaseWord))
                    {
                        wordsCount[lowercaseWord]++;
                    }
                }
            }

            foreach (var (word, count) in wordsCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(outputFilePath, $"{word} - {count}{Environment.NewLine}");
            }
        }
    }
}
