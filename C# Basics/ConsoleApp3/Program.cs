using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name = "Farhad Hesam Abbasi";

            //char firstLetter = name[0];

            //Console.Write($"{firstLetter}.");

            //int charPosition = name.IndexOf("Abbasi");
            //string name1 = name.Substring(charPosition);
            //Console.Write(name1);

            //int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            //Console.Write("Output : ");
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write(array[i] + " ");
            //}
            //Console.WriteLine();

            
                Console.WriteLine(DecoratePlanet("Jupiter"));
            


        }
        static string DecoratePlanet(string planet)
        {
            return $"*.*.* Welcome to {planet} *.*.*";
        }
    }
}
