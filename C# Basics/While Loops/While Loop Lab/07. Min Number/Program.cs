using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int minNumber = int.MaxValue;

            while (n != "Stop")
            {
                int currentNum = int.Parse(n);
                if (currentNum < minNumber)
                {
                    minNumber = currentNum;
                }
                n = Console.ReadLine();
            }
            Console.WriteLine(minNumber);
        }
    }
}
