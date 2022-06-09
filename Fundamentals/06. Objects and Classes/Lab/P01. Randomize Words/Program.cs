using System;

namespace P1._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random rnd = new Random();

            for (int index = 0; index < words.Length; index++)
            {
                int index2 = rnd.Next(words.Length);
                string temp = words[index];
                words[index] = words[index2];
                words[index2] = temp;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
