using System;
using System.IO;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var pngToCopy = new FileStream("../../../copyME.png", FileMode.Open))
            using (var copy = new FileStream("../../../copy.png", FileMode.Create))
            {
                pngToCopy.CopyTo(copy);
            }
        }
    }
}
