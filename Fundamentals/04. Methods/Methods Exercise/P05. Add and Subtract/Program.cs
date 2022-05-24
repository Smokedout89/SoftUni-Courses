using System;

namespace P05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = Sum(num1, num2);
            int finalResult = Subtract(result, num3);

            Console.WriteLine(finalResult);
        }

        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
