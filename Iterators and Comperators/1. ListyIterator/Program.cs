using System.Linq;
using System.Text;

namespace _1._ListyIterator
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {

            var creationData = Console.ReadLine().Split();
            if (creationData.Length == 1)
            {
                var listyList = new ListyIterator<string>();
                Operations(listyList);
            }
            else
            {
                var listyList = new ListyIterator<string>(creationData.Skip(1));
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
                else if (command == "PrintAll")
                {
                    var toPrint = new StringBuilder();
                    foreach (var element in collection)
                    {
                        toPrint.Append(element + " ");
                    }

                    Console.Write(toPrint);
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
