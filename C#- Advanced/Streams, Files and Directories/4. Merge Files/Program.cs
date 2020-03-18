using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var firstFile = new StreamReader("Text1.txt"))
            using (var secondFile = new StreamReader("Text2.txt"))
            using (var mergedFiles = new StreamWriter("MergedFiles.txt"))
            {
                while (!firstFile.EndOfStream && !secondFile.EndOfStream)
                {
                    var firstLine = firstFile.ReadLine();
                    var secondLine = secondFile.ReadLine();

                    mergedFiles.WriteLine(firstLine);
                    mergedFiles.WriteLine(secondLine);

                }
            }
        }
    }
}
