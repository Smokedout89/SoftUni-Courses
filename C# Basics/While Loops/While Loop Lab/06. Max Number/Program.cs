using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int maxNumber = int.MinValue;

            while (n != "Stop")
            {
                int currentNum = int.Parse(n);
                if (currentNum > maxNumber)
                {
                    maxNumber = currentNum;
                }
                n = Console.ReadLine();
            }
            Console.WriteLine(maxNumber);
        }
    }
}
