using System;

namespace P08.CollectionHierarchy.CollectionModels
{
    public abstract class IMyList<T> : IAddRemoveCollection<T>, ICollectionRemoveable<T>
    {
        public int Used => this.collection.Count;

        public override T Remove()
        {
            if (this.collection.Count == 0)
            {
                throw new ArgumentException("Collection is empty!");
            }

            var item = this.collection[0];
            this.collection.RemoveAt(0);
            return item;
        }
    }
}
