using System;

namespace P04._Refactoring_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int index = 2; index <= num; index++)
            {
                string isPrime = "true";

                for (int divider = 2; divider < index; divider++)
                {
                    if (index % divider == 0)
                    {
                        isPrime = "false";
                        break;
                    }
                }

                Console.WriteLine("{0} -> {1}", index, isPrime);
            }
        }
    }
}
