namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const int KettlebellGloveWeight = 10000;
        private const decimal KettlebellGlovePrice = 80;


        public Kettlebell() 
            : base(KettlebellGloveWeight, KettlebellGlovePrice)
        {
        }
    }
}