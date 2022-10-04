using FoodShortage.Contracts;
namespace BorderControl.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; }
        public int Age { get; set; }
        public string Id { get; set; }
        public int Food { get; set; } = 0;
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
