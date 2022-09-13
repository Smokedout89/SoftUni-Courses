using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAdress = Console.ReadLine().Split();
            string fullName = $"{nameAdress[0]} {nameAdress[1]}";
            string address = nameAdress[2];
            string town;

            if (nameAdress.Length == 4)
            {
                 town = nameAdress[3];
            }
            else  town = $"{nameAdress[3]} {nameAdress[4]}";

            string[] nameBeer = Console.ReadLine().Split();
            string name = nameBeer[0];
            int beer = int.Parse(nameBeer[1]);
            bool isDrunk = nameBeer[2] == "drunk" ? true : false;

            string[] bankBalance = Console.ReadLine().Split();
            string bankAccount = bankBalance[0];
            double balance = double.Parse(bankBalance[1]);
            string bankName = bankBalance[2];

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, address, town);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(name, beer, isDrunk);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(bankAccount, balance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
