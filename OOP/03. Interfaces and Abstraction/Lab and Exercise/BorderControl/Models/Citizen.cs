using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable, IBirthdateable
    {
        private string nameModel;

        //public Citizen(string nameModel, int age, string id)
        //{
        //    this.nameModel = nameModel;
        //    Age = age;
        //    Id = id;
        //}

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
    }
}
