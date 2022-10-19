namespace SpaceStation.Models
{
    using System.Collections.Generic;
    using Bags.Contracts;

    public class Backpack : IBag
    {
        private readonly ICollection<string> items;

        public Backpack()
        {
            items = new List<string>();
        }

        public ICollection<string> Items => items;
    }
}