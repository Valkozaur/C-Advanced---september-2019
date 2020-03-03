namespace CustomStack_Selfmade
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomStack
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomStack()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; set; }

        public void Push(int value)
        {
            if (this.Count >= this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = value;
            this.Count++;
        }

        public int Peek()
        {
            this.NotEmptyValidator();

            return this.items[this.Count - 1];
        }

        public int Pop()
        {
            this.NotEmptyValidator();
            this.Shrink();
            var itemToReturn = this.items[this.Count - 1];
            this.Count--;
            return itemToReturn;
        }

        public void Clear()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void Resize()
        {
            var resizedArray = new int[this.items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                resizedArray[i] = this.items[i];
            }

            this.items = resizedArray;
        }

        private void Shrink()
        {
            if (this.Count <= this.items.Length / 4)
            {
                var shrinkedArray = new int[this.items.Length / 4];
                for (int i = 0; i < this.Count; i++)
                {
                    this.items[i] = shrinkedArray[i];
                }

                this.items = shrinkedArray;
            }
        }

        private void NotEmptyValidator()
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty!");
            }
        }
    }
}
