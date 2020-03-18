using System;
using System.IO;
using System.Linq;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbolsToChange = new char[] { '-', ',', '.', '!', '?' };

            using (var streamReader = new StreamReader("../../../text.txt"))
            using(var streamWriter = new StreamWriter("../../../output.txt"))
            {
                var counter = 0;

                while (!streamReader.EndOfStream)
                {
                    var splittedLine = streamReader.ReadLine()
                        .Split()
                        .Reverse()
                        .ToArray();

                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < splittedLine.Length; i++)
                        {
                            foreach (var symbol in symbolsToChange)
                            {
                                splittedLine[i] = splittedLine[i].Replace(symbol, '@');
                            }
                        }

                        var text = String.Join(" ", splittedLine);
                        streamWriter.WriteLine(text);
                    }
                    counter++;
                }
            }

        }
    }
}
