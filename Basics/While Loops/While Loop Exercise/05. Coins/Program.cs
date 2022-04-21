using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double changeInCents = change * 100;
            int cents = (int) changeInCents;
            int coins = 0;
            while (cents > 0)
            {
                if (cents >= 200)
                {
                    cents -= 200;
                    coins++;
                }
                else  if (cents >= 100)
                {
                    cents -= 100;
                    coins++;                   
                }
                else if (cents >= 50)
                {
                    cents -= 50;
                    coins++;
                }
                else if (cents >= 20)
                {
                    cents -= 20;
                    coins++;
                }
                else if (cents >= 10)
                {
                    cents -= 10;
                    coins++;
                }
                else if (cents >= 5)
                {
                    cents -= 5;
                    coins++;
                }
                else if (cents >= 2)
                {
                    cents -= 2;
                    coins++;
                }
                else if (cents >= 1)
                {
                    cents -= 1;
                    coins++;
                }
            }
            Console.WriteLine(coins);
        }
    }
}
