namespace Easter.Models.Dyes
{
    using Contracts;

    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                power = value;
            }
        }

        public void Use()
        {
            Power -= 10;
        }

        public bool IsFinished() => Power == 0;
    }
}