namespace Restaurant
{
    public class Fish : MainDish
    {
        private const int fishGrams = 22;
        public Fish(string name, decimal price) : base(name, price, fishGrams)
        {
        }
    }
}
