using System;
using WildFarm.Contracts;
using WildFarm.Food;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double owlModifier = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound() => "Hoot Hoot";

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += owlModifier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
