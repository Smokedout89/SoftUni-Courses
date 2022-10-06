using System;
using WildFarm.Contracts;
using WildFarm.Food;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double tigerModifier = 1;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound() => "ROAR!!!";

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += tigerModifier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
