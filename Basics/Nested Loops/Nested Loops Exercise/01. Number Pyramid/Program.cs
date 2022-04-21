using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int row = 1;
            int currentN = 1;
            bool isEqual = false;

            while (!isEqual)
            {
                for (int i = 1; i <= row; i++)
                {
                    Console.Write($"{currentN} ");
                    currentN++;
                    if (currentN > n)
                    {
                        isEqual = true;
                        break;
                    }
                }
              Console.WriteLine();
              row++;
            }           
        }
    }
}
