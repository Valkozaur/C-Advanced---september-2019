namespace _5._Stack_of_Strings
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty);
            stackOfStrings.AddRange(new [] {"1", "2", "3"});
            Console.WriteLine(stackOfStrings.IsEmpty);
        }
    }
}
