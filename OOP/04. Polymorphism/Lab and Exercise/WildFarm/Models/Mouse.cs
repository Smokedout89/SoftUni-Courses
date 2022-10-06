using System;
using WildFarm.Contracts;
using WildFarm.Food;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double mouseModifier = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound() => "Squeak";

        public override void Eat(IFood food)
        {
            if (food is Fruit || food is Vegetable)
            {
                Weight += mouseModifier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
