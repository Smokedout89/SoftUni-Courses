using System.Collections.Generic;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public abstract class Collection : IAddCollection
    {
        protected Collection()
        {
            this.Data = new List<string>();
        }

        protected List<string> Data { get; }

        public virtual int Add(string item)
        {
            int index = 0;

            this.Data.Insert(index, item);
            return index;
        }
    }
}