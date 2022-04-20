using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string footballTeam = Console.ReadLine();
            string typeOfSouvenier = Console.ReadLine();
            int numberOfSouveniersBought = int.Parse(Console.ReadLine());
            double flagsPrice = 0;
            double capsPrice = 0;
            double postersPrice = 0;
            double stickersPrice = 0;
            double totalPrice = 0;
            switch (footballTeam)
            {
                case "Argentina":
                    flagsPrice = 3.25;
                    capsPrice = 7.20;
                    postersPrice = 5.10;
                    stickersPrice = 1.25;
                    break;
                case "Brazil":
                    flagsPrice = 4.20;
                    capsPrice = 8.50;
                    postersPrice = 5.35;
                    stickersPrice = 1.20;
                    break;
                case "Croatia":
                    flagsPrice = 2.75;
                    capsPrice = 6.90;
                    postersPrice = 4.95;
                    stickersPrice = 1.10;
                    break;
                case "Denmark":
                    flagsPrice = 3.10;
                    capsPrice = 6.50;
                    postersPrice = 4.80;
                    stickersPrice = 0.90;
                    break;
            }
            switch (typeOfSouvenier)
            {
                case "flags":
                    totalPrice = numberOfSouveniersBought * flagsPrice;
                    break;
                case "caps":
                    totalPrice = numberOfSouveniersBought * capsPrice;
                    break;
                case "posters":
                    totalPrice = numberOfSouveniersBought * postersPrice;
                    break;
                case "stickers":
                    totalPrice = numberOfSouveniersBought * stickersPrice;
                    break;
            }

            if (footballTeam != "Argentina" && footballTeam != "Brazil" && footballTeam != "Croatia" && footballTeam != "Denmark")
            {
                Console.WriteLine("Invalid country!");
            }
            else if (typeOfSouvenier != "flags" && typeOfSouvenier != "caps" && typeOfSouvenier != "posters" && typeOfSouvenier != "stickers")
            {
                Console.WriteLine("Invalid stock!");
            }
            else
            {
                Console.WriteLine($"Pepi bought {numberOfSouveniersBought} {typeOfSouvenier} of {footballTeam} for {totalPrice:f2} lv.");
            }

        }
    }
}
