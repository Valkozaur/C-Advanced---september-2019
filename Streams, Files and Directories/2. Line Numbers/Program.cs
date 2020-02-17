using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Input.txt");

            using (reader) 
            {
                int lineNumber = 1;
                string line = reader.ReadLine();

                using(StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while(line != null)
                    {
                        writer.WriteLine($"{lineNumber++}. {line}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
