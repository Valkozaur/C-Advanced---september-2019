using System;
using System.Collections.Generic;

namespace _4._Random_List
{
    public class RandomList<T> : List<T>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public T ReturnRandomElement()
        {
            var randomIndex = this.random.Next(0, this.Count);
            return this[randomIndex];
        }

        public T RemoveRandomElement()
        {
            var randomIndex = this.random.Next(0, this.Count);
            var element = this[randomIndex];
            this.RemoveAt(randomIndex);

            return element;
        }
    }
}
