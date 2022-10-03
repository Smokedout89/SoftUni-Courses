using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public virtual string Remove()
        {
            string item = this.Data[Data.Count - 1];
            this.Data.RemoveAt(Data.Count - 1);

            return item;
        }
    }
}