using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_selfwritten
{
    class DoublyLinkedList<T>
    {
        internal class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node<T> PreviousNode { get; set; }

            public Node<T> NextNode { get; set; }
        }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public int Count { get; private set; } = 0;

        public void AddHead(T value)
        {
            var newNode = new Node<T>(value);
            if (this.Count == 0)
            {
                this.Head = this.Tail = newNode;
            }
            else
            {
                var oldHead = this.Head;
                this.Head = newNode;
                this.Head.NextNode = oldHead;
                oldHead.PreviousNode = this.Head;
            }

            Count++;
        }

        public void AddTail(T value)
        {
            var newNode = new Node<T>(value);
            if (this.Count == 0)
            {
                this.Head = this.Tail = newNode;
            }
            else
            {
                var newTail = newNode;
                newTail.PreviousNode = this.Tail;
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }

            Count++;
        }


        public object RemoveHead()
        {
            var elementToReturn = Head;

            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            this.Head = this.Head.NextNode;
            if (Head.Value != null)
            {
                this.Head.PreviousNode = null;
            }
            else
            {
                this.Tail = null;
            }

            Count--;
            return elementToReturn;
        }

        public object RemoveTail()
        {
            var elementToReturn = Tail;

            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            this.Tail = this.Tail.PreviousNode;
            if (Tail != null)
            {
                this.Tail.NextNode = null;
            }
            else
            {
                this.Head = null;
            }

            Count--;
            return elementToReturn;
        }

        public void ForEach(Action<object> action)
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public object[] ToArray()
        {
            var currentNode = this.Head;
            var arrayToReturn = new object[this.Count];
            var indexer = 0;

            while (currentNode != null)
            {
                arrayToReturn[indexer] = currentNode;
                currentNode = currentNode.NextNode;
                indexer++;
            }

            return arrayToReturn;
        }
    }
}
