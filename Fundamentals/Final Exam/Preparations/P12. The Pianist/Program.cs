using System;
using System.Collections.Generic;

namespace _12._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> pieceComposer = new Dictionary<string, string>();
            Dictionary<string, string> pieceKey = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] argInfo = Console.ReadLine().Split('|');
                string piece = argInfo[0];
                string composer = argInfo[1];
                string key = argInfo[2];

                pieceComposer.Add(piece, composer);
                pieceKey.Add(piece, key);
            }

            string cmd = Console.ReadLine();

            while (cmd != "Stop")
            {
                string[] cmdArgs = cmd.Split('|');
                string command = cmdArgs[0];
                string piece = cmdArgs[1];

                if (command == "Add")
                {
                    string composer = cmdArgs[2];
                    string key = cmdArgs[3];

                    if (!pieceComposer.ContainsKey(piece))
                    {
                        pieceComposer.Add(piece, composer);
                        pieceKey.Add(piece, key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (pieceComposer.ContainsKey(piece))
                    {
                        pieceComposer.Remove(piece);
                        pieceKey.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string newKey = cmdArgs[2];

                    if (pieceKey.ContainsKey(piece))
                    {
                        pieceKey[piece] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                cmd = Console.ReadLine();
            }

            foreach (var composer in pieceComposer)
            {
                string piece = composer.Key;
                string key = pieceKey[piece];
                
                Console.WriteLine($"{composer.Key} -> Composer: {composer.Value}, Key: {key}");
            }
        }
    }
}
