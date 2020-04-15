namespace P08.CollectionHierarchy.CollectionModels
{
    using System.Collections.Generic;

    public interface IAddCollection<T>
    {
        IReadOnlyCollection<T> Collection { get; }

        int Add(T item);
    }
}
