namespace _4._Froggy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(params int[] stonesInput)
        {
            this.stones = stonesInput.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < stones.Count; i+=2)
            {
                yield return stones[i];
            }

            var reverseJumpStartIndex = stones.Count % 2 != 0
                ? stones.Count - 2
                : stones.Count - 1;

            for (var i = reverseJumpStartIndex; i >= 0; i-=2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}