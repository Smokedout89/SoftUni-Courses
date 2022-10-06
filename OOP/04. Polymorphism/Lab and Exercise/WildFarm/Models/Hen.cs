using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double henModifier = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound() => "Cluck";
        public override void Eat(IFood food)
        {
            Weight += henModifier * food.Quantity;
            FoodEaten += food.Quantity;
        }
    }
}
