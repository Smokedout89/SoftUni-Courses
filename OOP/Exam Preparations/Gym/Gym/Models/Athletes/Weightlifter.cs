namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int WeightLifterStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, WeightLifterStamina)
        {
        }

        public override void Exercise()
        {
            Stamina += 10;
        }
    }
}