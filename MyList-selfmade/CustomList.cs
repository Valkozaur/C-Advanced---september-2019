namespace MyList_selfmade
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; set; }

        public void Add(int value)
        {
            if (this.Count >= this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = value;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            this.IndexValidator(index);
            this.ShiftLeft(index);
            this.items[this.Count - 1] = default;
            this.Count--;
            var shrinkIsNeeded = this.Count <= this.items.Length / 4;
            if (shrinkIsNeeded)
            {
                this.ShrinkSize();
            }
        }

        public void Insert(int index, int value)
        {
            this.IndexValidator(index);
            if (this.Count >= this.items.Length)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            this.items[index] = value;
            this.Count++;
        }       

        public bool Contains(int value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.IndexValidator(firstIndex);
            this.IndexValidator(secondIndex);
            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        private void ShrinkSize()
        {
            var shrinkedArray = new int[this.items.Length / 4];
            for (int i = 0; i < this.Count; i++)
            {
                shrinkedArray[i] = this.items[i];
            }

            this.items = shrinkedArray;
        }

        private void Resize()
        {
            var newArray = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

            this.items = newArray;
        }

        private void IndexValidator(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i + 1] = this.items[i];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
    }
}
