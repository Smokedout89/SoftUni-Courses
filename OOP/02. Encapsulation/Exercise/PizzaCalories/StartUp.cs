using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];
                string[] doughInfo = Console.ReadLine().Split();
                string doughType = doughInfo[1];
                string doughTechnique = doughInfo[2];
                double doughWeight = double.Parse(doughInfo[3]);
                Dough dough = new Dough(doughType, doughTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingCmd = Console.ReadLine();

                while (toppingCmd != "END")
                {
                    string[] toppingInfo = toppingCmd.Split();
                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    toppingCmd = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
