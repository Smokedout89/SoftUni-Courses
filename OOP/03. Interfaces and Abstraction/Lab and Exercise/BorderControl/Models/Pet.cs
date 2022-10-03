using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Pet : IBirthdateable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; }
        public string Birthdate { get; }
    }
}