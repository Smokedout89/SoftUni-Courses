using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJoinery = int.Parse(Console.ReadLine());
            string typeOfJoinery = Console.ReadLine();
            string deliveryOption = Console.ReadLine();
            const int deliveryPrice = 60;
            double soloPrice = 0;

            switch (typeOfJoinery)
            {
                case "90X130":
                    soloPrice = 110;
                    if (numberOfJoinery > 60)
                    {
                        soloPrice *= 0.92;
                    }
                    else if (numberOfJoinery > 30)
                    {
                        soloPrice *= 0.95;
                    }   
                 break;
                case "100X150":
                    soloPrice = 140;
                    if (numberOfJoinery > 80)
                    {
                        soloPrice *= 0.9;
                    }
                    else if (numberOfJoinery > 40)
                    {
                        soloPrice *= 0.94;
                    }
                    break;
                case "130X180":
                    soloPrice = 190;
                    if (numberOfJoinery > 50)
                    {
                        soloPrice *= 0.88;
                    }
                    else if (numberOfJoinery > 20)
                    {
                        soloPrice *= 0.97;
                    }
                    break;
                case "200X300":
                    soloPrice = 250;
                    if (numberOfJoinery > 50)
                    {
                        soloPrice *= 0.86;
                    }
                    else if (numberOfJoinery > 25)
                    {
                        soloPrice *= 0.91;
                    }
                    break;
            }

            double totalPrice = numberOfJoinery * soloPrice;

            if (deliveryOption == "With delivery")
            {
                totalPrice += deliveryPrice;
            }

            if (numberOfJoinery > 99)
            {
                totalPrice *= 0.96;
            }

            if (numberOfJoinery < 10)
            {
                Console.WriteLine("Invalid order");
            }
            else
            {
                Console.WriteLine($"{totalPrice:f2} BGN");
            }
          
        }
    }
}
