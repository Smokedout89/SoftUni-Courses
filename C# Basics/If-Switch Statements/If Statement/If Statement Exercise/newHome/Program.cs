using System;

namespace newHome
{
    class Program
    {
        static void Main(string[] args)
        {

            const double rose = 5, dahlia = 3.80, tulip = 2.80, narcissus = 3, gladiolus = 2.50;

            string typeFlower = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0;

            switch (typeFlower)
            {
                case "Roses":
                    if (numberOfFlowers > 80)
                    {
                        price -= numberOfFlowers * rose * 0.1;
                    }
                    price += numberOfFlowers * rose;
                    break;
                case "Dahlias":
                    if (numberOfFlowers > 90)
                    {
                        price -= numberOfFlowers * dahlia * 0.15;
                    }
                    price += numberOfFlowers * dahlia;
                    break;
                case "Tulips":
                    if (numberOfFlowers > 80)
                    {
                        price -= numberOfFlowers * tulip * 0.15;
                    }
                    price += numberOfFlowers * tulip;
                    break;
                case "Narcissus":
                    if (numberOfFlowers < 120)
                    {
                        price += numberOfFlowers * narcissus * 0.15;
                    }
                    price += numberOfFlowers * narcissus;
                    break;
                case "Gladiolus":
                    if (numberOfFlowers < 80)
                    {
                        price += numberOfFlowers * gladiolus * 0.20;
                    }
                    price += numberOfFlowers * gladiolus;
                    break;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeFlower} and {budget-price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price-budget:f2} leva more.");
            }

        }
    }
}
