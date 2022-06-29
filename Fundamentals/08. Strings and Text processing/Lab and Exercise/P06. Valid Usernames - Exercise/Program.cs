using System;
using System.Collections.Generic;

namespace P06._Valid_Usernames___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            List<string> validUsers = new List<string>();

            foreach (string currWord in input)
            {
                bool isValid = true;

                if (currWord.Length >= 3 && currWord.Length <= 16)
                {
                    foreach (char ch in currWord)
                    {
                        if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        validUsers.Add(currWord);
                    }
                }
            }

            foreach (string validUser in validUsers)
            {
                Console.WriteLine(validUser);
            }
        }
    }
}
