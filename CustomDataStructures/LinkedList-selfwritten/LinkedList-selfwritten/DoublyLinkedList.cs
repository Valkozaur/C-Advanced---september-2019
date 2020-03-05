using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_selfwritten
{
    class DoublyLinkedList
    {
        internal class Node
        {
            public Node(object value)
            {
                this.Value = value;
            }

            public object Value { get; set; }

            public Node PreviousNode { get; set; }

            public Node NextNode { get; set; }
        }

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Count { get; private set; } = 0;

        public void AddHead(object value)
        {
            var newNode = new Node(value);
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

        public void AddTail(object value)
        {
            var newNode = new Node(value);
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
