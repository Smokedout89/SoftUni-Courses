using System;

namespace P03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal numA = decimal.Parse(Console.ReadLine());
            decimal numB = decimal.Parse(Console.ReadLine());

            const decimal allowedDiff = 0.000001m;
            decimal difference = Math.Abs(numA - numB);
            bool isEqual;

            if (difference >= allowedDiff)
            {
                isEqual = false;
            }
            else
            {
                isEqual = true;
            }

            Console.WriteLine(isEqual);
        }
    }
}
