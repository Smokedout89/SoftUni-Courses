using System;
using WildFarm.Contracts;
using WildFarm.Food;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double dogModifier = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound() => "Woof!";

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += dogModifier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
