namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const int BoxingGloveWeight = 227;
        private const decimal BoxingGlovePrice = 120;

        public BoxingGloves() 
            : base(BoxingGloveWeight, BoxingGlovePrice)
        {
        }
    }
}