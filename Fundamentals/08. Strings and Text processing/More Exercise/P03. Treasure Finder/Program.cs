using System;
using System.Linq;
using System.Text;

namespace P03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "find")
            {
                StringBuilder message = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    message.Append(Convert.ToChar(input[i] - sequence[i % sequence.Length]));
                }

                string messageAsString = message.ToString();

                int startIndexOfTreasure = messageAsString.IndexOf("&") + 1; 
                int treasureLength = messageAsString.LastIndexOf("&") - startIndexOfTreasure;

                string treasure = messageAsString.Substring(startIndexOfTreasure, treasureLength);

                int startIndexOfCoord = messageAsString.IndexOf("<") + 1;
                int coordinatesLenght = messageAsString.IndexOf(">") - startIndexOfCoord;

                string coordinates = messageAsString.Substring(startIndexOfCoord, coordinatesLenght);

                Console.WriteLine($"Found {treasure} at {coordinates}");

                input = Console.ReadLine();
            }
        }
    }
}
