using System;
using System.Linq;
using System.Collections.Generic;

namespace Food_Finder
{
    internal class FoodFinder
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse));
            Stack<char> consonant = new Stack<char>(Console.ReadLine().Split().Select(char.Parse));

            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>()
            {
                {"pear", new HashSet<char>()},
                {"flour", new HashSet<char>()},
                {"pork", new HashSet<char>()},
                {"olive", new HashSet<char>()}
            };

            while (consonant.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonant.Pop();

                foreach (var word in words)
                {
                    if (word.Key.Contains(currentVowel))
                    {
                        word.Value.Add(currentVowel);
                    }

                    if (word.Key.Contains(currentConsonant))
                    {
                        word.Value.Add(currentConsonant);
                    }
                }

                vowels.Enqueue(currentVowel);
            }

            var completedWords = words.Where(a => a.Key.Length == a.Value.Count);

            Console.WriteLine($"Words found: {completedWords.Count()}");

            foreach (var word in completedWords)    
            {
                Console.WriteLine(word.Key);
            }
        }
    }
}
