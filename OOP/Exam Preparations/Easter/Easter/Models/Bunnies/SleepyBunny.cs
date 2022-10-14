namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int SleepyBunnyEnergy = 50;

        public SleepyBunny(string name) 
            : base(name, SleepyBunnyEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            Energy -= 5;
        }
    }
}