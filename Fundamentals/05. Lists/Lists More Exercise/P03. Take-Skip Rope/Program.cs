using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> text = Console.ReadLine().ToList();
            List<int> digits = new List<int>();

            for (int i = 0; i < text.Count; i++)
            {
                if (char.IsNumber(text[i]))
                {
                    int currNum = int.Parse(text[i].ToString());
                    digits.Add(currNum);
                    text.Remove(text[i]);
                    i--;
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0) takeList.Add(digits[i]);
                else skipList.Add(digits[i]);
            }
            
            string result = String.Empty;
            int index = 0;

            for (int i = 0; i < skipList.Count; i++)
            {
                int skipCount = skipList[i];
                int takeCount = takeList[i];
                result += new string(text.Skip(index).Take(takeCount).ToArray());
                index += skipCount + takeCount;
            }

            Console.WriteLine(result);

        }
    }
}
