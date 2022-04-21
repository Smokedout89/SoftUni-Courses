using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int toyCount = 0;
            int currentMoney = 0;
            int moneyTotal = 0;

            for (int i = 1; i <= age; i++)
            {
                currentMoney += 5;              
                if (i % 2 == 0)
                {
                    moneyTotal += currentMoney - 1;
                }
                else
                {
                    toyCount++;
                }
            }
            moneyTotal += toyCount * toyPrice;
            double diff = Math.Abs(washingMachinePrice - moneyTotal);
            if (moneyTotal >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
