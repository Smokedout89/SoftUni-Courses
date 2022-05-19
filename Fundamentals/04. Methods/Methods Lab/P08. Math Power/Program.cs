using System;

namespace P08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNum = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(Powered(baseNum, power));
        }

        static double Powered(double baseNum, int power)
        {
            double result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseNum;
            }

            return result;
        }
    }
}
