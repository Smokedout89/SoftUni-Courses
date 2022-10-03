using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddCollection : Collection, IAddCollection
    {
        public override int Add(string item)
        {
            base.Add(item);

            return this.Data.Count - 1;
        }
    }
}