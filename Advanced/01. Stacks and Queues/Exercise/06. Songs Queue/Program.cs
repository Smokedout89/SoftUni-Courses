using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initialSongs = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(initialSongs);

            while (songs.Count > 0)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    int index = cmd.IndexOf(' ');
                    string song = cmd.Substring(index + 1);

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
