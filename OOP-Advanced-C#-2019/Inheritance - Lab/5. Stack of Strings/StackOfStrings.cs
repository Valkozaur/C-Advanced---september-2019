namespace _5._Stack_of_Strings
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty => this.Count == 0;

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
        }
    }
}
