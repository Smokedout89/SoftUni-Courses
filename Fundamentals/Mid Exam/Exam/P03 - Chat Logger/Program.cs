using System;
using System.Collections.Generic;
using System.Linq;

namespace P03___Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> result = new List<string>();

            while (input != "end")
            {
                string[] token = input.Split();
                string command = token[0];

                if (command == "Chat")
                {
                    string msg = token[1];
                    result.Add(msg);
                }
                else if (command == "Delete")
                {
                    string msg = token[1];
                    if (result.Contains(msg))
                    {
                        result.Remove(msg);
                    }
                }
                else if (command == "Edit")
                {
                    string msg = token[1];
                    string newMsg = token[2];
                    if (result.Contains(msg))
                    {
                        int index = result.IndexOf(msg);
                        result.Remove(msg);
                        result.Insert(index, newMsg);
                    }
                }
                else if (command == "Pin")
                {
                    string msg = token[1];
                    if (result.Contains(msg))
                    {
                        string saveIt = msg;
                        result.Remove(msg);
                        result.Add(saveIt);
                    }
                }
                else if (command == "Spam")
                {
                    for (int i = 1; i < token.Length; i++)
                    {
                        string currWord = token[i];
                        result.Add(currWord);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var elemnt in result)
            {
                Console.WriteLine(elemnt);
            }
        }
    }
}
