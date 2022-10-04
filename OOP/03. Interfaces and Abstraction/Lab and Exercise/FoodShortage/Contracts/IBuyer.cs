namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }

        void BuyFood();
    }
}