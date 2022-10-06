using System;
using WildFarm.Contracts;
using WildFarm.Food;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double catModifier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound() => "Meow";

        public override void Eat(IFood food)
        {
            if (food is Meat || food is Vegetable)
            {
                Weight += catModifier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
