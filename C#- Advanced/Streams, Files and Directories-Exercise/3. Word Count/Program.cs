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
            var words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> dictionaryOfWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                dictionaryOfWords.Add(word, 0);
            }

            string text = File.ReadAllText("../../../TEXT.txt").ToLower();
            string[] splittedText = text
                .Split(new char[] { ',', '.', ' ', '!', '?', '-' });
            File.WriteAllText("../../../actualResults.txt", text);

            foreach (var word in splittedText)
            {
                if (dictionaryOfWords.ContainsKey(word))
                {
                    dictionaryOfWords[word]++;
                }
            }

            string textOutput = String.Join(Environment.NewLine, dictionaryOfWords.Select(kvp => $"{kvp.Key} -{kvp.Value}"));

            File.WriteAllText("../../../actualResults.txt", textOutput);
        }
    }
}
