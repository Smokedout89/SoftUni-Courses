using System;
using System.Collections.Generic;
using System.Linq;

namespace P3._Songs
{

    class Song
    {
        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }

        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numOfSongs; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split("_");

                string typeList = cmdArgs[0];
                string name = cmdArgs[1];
                string time = cmdArgs[2];

                Song newSong = new Song(typeList, name, time);

                songs.Add(newSong);
            }

            string typeListToPrint = Console.ReadLine();

            if (typeListToPrint == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.FindAll(song => song.TypeList == typeListToPrint);

                foreach (var song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }

        }
    }
}
