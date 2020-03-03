namespace CustomStack_Selfmade
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var customStack = new CustomStack();

            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            customStack.Push(4);
            customStack.Push(5);

            Console.WriteLine(customStack.Count == 5);

            var item = customStack.Pop();
            Console.WriteLine(item == 5);
            Console.WriteLine(customStack.Count == 4);

            item = customStack.Peek();
            Console.WriteLine(item == 4);
            Console.WriteLine(customStack.Count == 4);

            customStack.Push(5);

            customStack.ForEach(Console.WriteLine);

            customStack.Clear();
            Console.WriteLine(customStack.Count == 0);
        }
    }
}
