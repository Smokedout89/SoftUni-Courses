namespace Restaurant
{
    public class Cake : Dessert
    {
        private const int cakeGrams = 250;
        private const int cakeCalories = 1000;
        private const int cakePrice = 5;
        public Cake(string name) : base(name, cakePrice, cakeGrams, cakeCalories)
        {
        }
    }
}
