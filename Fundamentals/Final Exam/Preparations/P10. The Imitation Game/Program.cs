using System;

namespace _10._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMsg = Console.ReadLine();

            string inputCmd = Console.ReadLine();

            while (inputCmd != "Decode")
            {
                string[] cmdArgs = inputCmd.Split('|');
                string command = cmdArgs[0];

                if (command == "Move")
                {
                    int numToMove = int.Parse(cmdArgs[1]);
                    string modified = encryptedMsg.Substring(0, numToMove);
                    encryptedMsg = encryptedMsg.Remove(0, numToMove);
                    encryptedMsg += modified;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    encryptedMsg = encryptedMsg.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    encryptedMsg = encryptedMsg.Replace(substring, replacement);
                }

                inputCmd = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMsg}");
        }
    }
}
