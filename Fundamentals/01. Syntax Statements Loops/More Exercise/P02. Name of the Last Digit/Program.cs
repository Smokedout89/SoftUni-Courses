using System;

namespace P02._Name_of_the_Last_Digit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            char lastDigit = num[num.Length - 1];
            PrintName(lastDigit);


            static void PrintName(char lastDigit)
            {
                switch (lastDigit)
                {
                    case '0': Console.WriteLine("zero"); break;
                    case '1': Console.WriteLine("one"); break;
                    case '2': Console.WriteLine("twoo"); break;
                    case '3': Console.WriteLine("three"); break;
                    case '4': Console.WriteLine("four"); break;
                    case '5': Console.WriteLine("five"); break;
                    case '6': Console.WriteLine("six"); break;
                    case '7': Console.WriteLine("seven"); break;
                    case '8': Console.WriteLine("eight"); break;
                    case '9': Console.WriteLine("nine"); break;
                }
            }
        }
    }
}
