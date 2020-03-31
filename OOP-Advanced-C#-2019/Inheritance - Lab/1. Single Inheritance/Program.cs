using System;

namespace _1._Single_Inheritance
{
    public class StartUp
    {
        public static void Main()
        {
            var cat = new Cat();
            cat.Meow();
            cat.Eat();
            var dog = new Dog();
            dog.Bark();
            dog.Eat();
        }
    }
}
