using System;

namespace _4._Random_List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var randomList = new RandomList<int>();
            randomList.Add(1);
            randomList.Add(2);
            randomList.Add(3);
            randomList.Add(4);
            Console.WriteLine(randomList.ReturnRandomElement());
            Console.WriteLine(randomList.RemoveRandomElement());
        }
    }
}
