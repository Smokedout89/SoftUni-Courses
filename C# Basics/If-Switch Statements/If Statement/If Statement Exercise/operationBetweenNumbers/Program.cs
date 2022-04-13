using System;

namespace operationBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double result = 0;
            if (symbol == "+")
            {
                result = N1 + N2;
            }
            else if (symbol == "-")
            {
                result = N1 - N2;
            }
            else if (symbol == "*")
            {
                result = N1 * N2;
            }
            else if (symbol == "/")
            {
                result = N1 / N2;
            }
            else if (symbol == "%")
            {
                result = N1 % N2;
            }

            if (N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
            else if (symbol == "/")
            {
                Console.WriteLine($"{N1} / {N2} = {result:f2}");
            }
            else if (symbol == "%")
            {
                Console.WriteLine($"{N1} % {N2} = {result}");
            }
            else if (symbol == "+" || symbol == "-" || symbol == "*")
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {result} - odd");
                }
            }
        }
    }
}
