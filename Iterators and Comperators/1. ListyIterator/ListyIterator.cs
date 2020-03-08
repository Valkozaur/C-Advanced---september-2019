using System.Collections;

namespace _1._ListyIterator
{
    using System.Collections.Generic;
    using System.Linq;
    public class ListyIterator<T> : IEnumerable<T>
    {
        private const int internalIndexInitialValue= 0;

        private List<T> collection;
        private int internalIndex;

        public ListyIterator()
        {
            this.collection = new List<T>();
            this.internalIndex = internalIndexInitialValue;
        }
        public ListyIterator(IEnumerable<T> initialData)
        {
            this.collection = new List<T>(initialData);
        }

        public string Move()
        {
            if (internalIndex + 1 >= collection.Count)
            {
                return "False";
            }
            else
            {
                internalIndex++;
                return "True";
            }
        }

        public string HasNext()
        {
            if (internalIndex + 1 >= collection.Count)
            {
                return "False";
            }

            return "True";
        }

        public string Print()
        {
            if (collection.Count == 0)
            {
                return "Invalid Operation!";
            }
            else
            {
                return collection[internalIndex].ToString();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in collection)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
