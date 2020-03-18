using System.Collections;
using System.Collections.Generic;

namespace _4._Froggy
{
    public class StonesEnumerator : IEnumerator<int>
    {
        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            Current = 0;
        }

        public int Current { get; }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}