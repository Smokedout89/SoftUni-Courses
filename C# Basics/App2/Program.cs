using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };

            //int lenght = array.Length;
            //int[] reversed = new int[lenght];

            //for (int i = 0; i < lenght; i++)
            //{
            //    reversed[lenght - i - 1] = array[i];
            //}

            //for (int i = 0; i < lenght; i++)
            //{
            //    Console.Write(reversed[i] + " ");
            //}

            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            bool symmetric = true;

            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[n - i - 1])
                {
                    symmetric = false;
                    break;
                }
            }

            Console.WriteLine("Is symmetric? {0}", symmetric);
        }
    }
}
