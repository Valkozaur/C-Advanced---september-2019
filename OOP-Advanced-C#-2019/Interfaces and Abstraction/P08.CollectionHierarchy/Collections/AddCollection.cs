namespace P08.CollectionHierarchy.Collections
{
    using CollectionModels;
    using System.Collections.Generic;

    public class AddCollection<T> : IAddCollection<T>
    {
        private List<T> collection;

        public AddCollection()
        {
            this.collection = new List<T>();
        }

        public IReadOnlyCollection<T> Collection => this.collection;

        public int Add(T item)
        {
            this.collection.Add(item);
            return collection.Count - 1;
        }
    }
}
