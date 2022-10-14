namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int HappyBunnyEnergy = 100;

        public HappyBunny(string name) 
            : base(name, HappyBunnyEnergy)
        {
        }
    }
}