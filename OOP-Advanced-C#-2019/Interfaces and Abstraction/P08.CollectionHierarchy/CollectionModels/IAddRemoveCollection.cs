using System;
using System.Collections.Generic;

namespace P08.CollectionHierarchy.CollectionModels
{
    public abstract class IAddRemoveCollection<T> : IAddCollection<T>, ICollectionRemoveable<T>
    {
        public IAddRemoveCollection()
        {
            this.collection = new List<T>();
        }

        protected List<T> collection;

        public IReadOnlyCollection<T> Collection => this.collection;

        public int Add(T item)
        {
            // always add to the begining of the collection

            this.collection.Insert(0, item);
            return 0;

        }

        public virtual T Remove()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("Invalid argument!");
            }

            var item = this.collection[collection.Count - 1];

            this.collection.RemoveAt(collection.Count - 1);

            return item;
        }
    }
}
