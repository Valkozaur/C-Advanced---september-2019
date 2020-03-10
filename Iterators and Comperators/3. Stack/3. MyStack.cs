using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Xsl;

namespace _3._Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int count = 0;

        public MyStack()
        {
            this.collection = new List<T>(2);
        }

        public void Push(T item)
        {
            collection.Insert(count, item);
            count++;
        }

        public T Pop()
        {
            
            return collection[--count];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
