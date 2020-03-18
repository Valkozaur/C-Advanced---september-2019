namespace _1._ListyIterator
{
    using System.Collections.Generic;
    using System.Linq;
    public class ListyIterator<T>
    {
        private List<string> collection;
        private int internalIndex = 0;

        public ListyIterator()
        {
            this.collection = new List<string>();
        }
        public ListyIterator(string collectionInput)
        {
            this.collection = collectionInput.Split(" ").ToList();
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
                return collection[internalIndex];
            }
        }
    }
}
