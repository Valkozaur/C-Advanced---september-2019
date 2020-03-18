using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader wordsInput = new StreamReader("words.txt");
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (wordsInput)
            {
                string[] line = wordsInput.ReadLine()
                    .Split(" ");

                foreach (var word in line)
                {
                    wordsCount.Add(word, 0);
                }
            }

            StreamReader readerInput = new StreamReader("Input.txt");

            using (readerInput)
            {
                while (!readerInput.EndOfStream)
                {
                    string line = readerInput.ReadLine()
                        .ToLower();

                    string[] splittedLine = line
                    .Split(new char[] { '1','?','-','.',' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in splittedLine)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }

                }
            }

            wordsCount = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var (word, count) in wordsCount)
            {
                Console.WriteLine($"{word} - {count}");
            }
        }
    }
}
