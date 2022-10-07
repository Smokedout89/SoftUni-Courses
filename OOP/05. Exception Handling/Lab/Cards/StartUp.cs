using System;
using System.Collections.Generic;

namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> faces = new List<string>
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };
            Dictionary<string, string> suits = new Dictionary<string, string>
            {
                { "S", "\u2660" },
                { "H", "\u2665" },
                { "D", "\u2666" },
                { "C", "\u2663" }
            };

            string[] input = Console.ReadLine().Split(", ");
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var item in input)
            {
                string face = item.Split(' ')[0];
                string suit = item.Split(' ')[1];

                try
                {
                    if (faces.Contains(face) && suits.ContainsKey(suit))
                    {
                        result.Add(face, suit);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }               
            }

            foreach (var pair in result)
            {
                Console.Write($"[{pair.Key}{suits[pair.Value]}] ");
            }
            Console.WriteLine();
        }
    }
}
