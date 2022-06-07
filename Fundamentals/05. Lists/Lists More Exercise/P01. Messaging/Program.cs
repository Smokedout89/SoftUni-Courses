using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<char> text = Console.ReadLine().ToList();

            for (int i = 0; i < input.Count; i++)
            {
                int index = 0;
                int currNum = input[i];

                while (currNum > 0)
                {
                    int currDigit = currNum % 10;
                    index += currDigit;
                    currNum /= 10;
                }

                if (index > text.Count)
                {
                    index -= text.Count;
                }

                Console.Write(text[index]);
                text.RemoveAt(index);
            }

            Console.WriteLine();
        }
    }
}
