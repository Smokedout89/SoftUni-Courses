namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int claymoreDmg = 20;

        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability > 0)
            {
                Durability--;

                return claymoreDmg;
            }

            return 0;
        }
    }
}