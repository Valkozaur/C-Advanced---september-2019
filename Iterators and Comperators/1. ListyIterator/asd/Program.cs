namespace _1._ListyIterator
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {

            var create = Console.ReadLine();
            if (create.EndsWith("Create"))
            {
                var listyList = new ListyIterator<string>();
                Operations(listyList);
            }
            else
            {
                var collection = create.Substring(create.IndexOf(" ") + 1);
                var listyList = new ListyIterator<string>(collection);
                Operations(listyList);
            }
        }

        public static void Operations(ListyIterator<string> collection)
        {
            while (true)
            {
                var command = Console.ReadLine();
                var elementToPrint = String.Empty;

                if (command == "Move")
                {
                    elementToPrint = collection.Move();
                }
                else if (command == "HasNext")
                {
                    elementToPrint = collection.HasNext();
                }
                else if (command == "Print")
                {
                    elementToPrint = collection.Print();
                }
                else if (command == "END")
                {
                    break;
                }

                Console.WriteLine(elementToPrint);
            }
        }
    }
}
