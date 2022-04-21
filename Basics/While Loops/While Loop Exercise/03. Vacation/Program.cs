using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int spendingDaysCounter = 0;
            int daysCounter = 0;
            while (spendingDaysCounter != 5)
            {
                string spendOrSave = Console.ReadLine();
                double moneyToSpendSave = double.Parse(Console.ReadLine());
                daysCounter++;
                if (spendOrSave == "save")
                {
                    availableMoney += moneyToSpendSave;
                    spendingDaysCounter = 0;
                }          
                 else if (spendOrSave == "spend")
                 {
                    spendingDaysCounter++;
                    if (availableMoney < moneyToSpendSave)
                    {
                        availableMoney = 0;
                    }
                    else
                    {
                    availableMoney -= moneyToSpendSave;
                    }
                 }
                if (availableMoney >= moneyNeeded)
                {
                    Console.WriteLine($"You saved the money for {daysCounter} days.");
                    break;
                }
            }          
            if (spendingDaysCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{daysCounter}");
            }

        }
    }
}
