using System;

namespace P10._Rage_expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int hCount = 0;
            int mCount = 0;
            int kCount = 0;
            int dCount = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    hCount++;
                }
                if (i % 3 == 0)
                {
                    mCount++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    kCount++;
                }

            }
            dCount = kCount / 2;

            double totalH = headsetPrice * hCount;
            double totalM = mousePrice * mCount;
            double totalK = keyboardPrice * kCount;
            double totalD = displayPrice * dCount;

            double total = totalD + totalH + totalK + totalM;

            Console.WriteLine($"Rage expenses: {total:f2} lv.");
        }
    }
}
