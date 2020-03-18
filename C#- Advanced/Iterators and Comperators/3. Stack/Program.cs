using System.Linq;
using System.Runtime.CompilerServices;

namespace _3._Stack
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            var myStack = new MyStack<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        foreach (var element in myStack)
                        {
                            Console.WriteLine(element);
                        }
                    }
                    break;
                }

                if (input.StartsWith("Push"))
                {
                    var itemsToPush = input
                        .Substring(input.IndexOf(" ") + 1)
                        .Split(", ");

                    foreach (var item in itemsToPush)
                    {
                        myStack.Push(item);
                    }
                }
                else if (input == "Pop")
                {
                    if (!myStack.Any())
                    {
                        Console.WriteLine("No elements");
                        continue;
                    }
                    myStack.Pop();
                }
            }
        }
    }
}
