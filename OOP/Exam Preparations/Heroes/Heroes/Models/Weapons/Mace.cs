namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int maceDmg = 25;

        public Mace(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability > 0)
            {
                Durability--;

                return maceDmg;
            }

            return 0;
        }
    }
}