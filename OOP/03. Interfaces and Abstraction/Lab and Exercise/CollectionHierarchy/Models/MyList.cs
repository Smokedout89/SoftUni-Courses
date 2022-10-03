using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public override string Remove()
        {
            string item = this.Data[0];
            this.Data.RemoveAt(0);

            return item;
        }

        public int Used => this.Data.Count;
    }
}