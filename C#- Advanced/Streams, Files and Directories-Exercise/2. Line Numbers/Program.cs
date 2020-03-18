using System;
using System.Collections.Generic;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesOfText = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < linesOfText.Length; i++)
            {
                var currentLine = linesOfText[i];
                var countOfLetters = 0;
                var countOfPuncMarks = 0;

                foreach (var symbol in currentLine)
                {
                    if (char.IsLetter(symbol))
                    {
                        countOfLetters++;
                    }
                    else if (char.IsPunctuation(symbol))
                    {
                        countOfPuncMarks++;
                    }
                }
                linesOfText[i] = $"Line {i + 1}: {currentLine} ({countOfLetters})({countOfPuncMarks})";
            }
            File.WriteAllLines("../../../output.txt", linesOfText);
        }
    }
}
