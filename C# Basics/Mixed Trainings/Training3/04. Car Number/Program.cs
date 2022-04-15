using System;

namespace _04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

            for (int i = start; i <= finish; i++)
            {
                for (int j = start; j <= finish; j++)
                {
                    for (int k = start; k <= finish; k++)
                    {
                        for (int l = start; l <= finish; l++)
                        {
                            if (i % 2 == 0 && l % 2 != 0 && i > l && (j + k) % 2 == 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                            else if (i % 2 != 0 && l % 2 == 0 && i > l && (j + k) % 2 == 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
