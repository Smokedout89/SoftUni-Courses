namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int BoxerStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, BoxerStamina)
        {
        }
        
        public override void Exercise()
        {
            Stamina += 15;
        }
    }
}