using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFile = @"C:\Users\valni\OneDrive\Desktop\SoftUni\Repositorys\Advanced-C#-2019\Streams, Files and Directories\5. Slice a File\sliceMe.txt";
            var parts = 4;
            var fileLenght = new FileInfo("sliceMe.txt").Length;
            var fileSize = (int)(fileLenght / parts);
            var fileNumber = 1;

            using (var fileToSlice = new StreamReader(sourceFile))
            {
                while (!fileToSlice.EndOfStream)
                {
                    var bufferSize = fileSize;
                    if (fileNumber == parts)
                    {
                        bufferSize = (int)fileLenght - (parts - 1) * fileSize;
                    }

                    var buffer = new char[bufferSize];
                    var files = fileToSlice.Read(buffer, 0, buffer.Length);

                    using (var filesToCreate = new StreamWriter($"Part-{fileNumber++}.txt"))
                    {
                        filesToCreate.Write(buffer);
                    }
                }
            }
        }
    }
}
