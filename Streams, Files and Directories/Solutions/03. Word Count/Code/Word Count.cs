using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace WordCount {
    public class WordCount {
        static void Main() {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordPath, string textPath, string outputPath) {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            
            using (StreamReader reader = new StreamReader(wordPath)) {
                while (!reader.EndOfStream) {
                    string[] line = reader.ReadLine().Split().ToArray();
                    
                    for (int i = 0; i < line.Length; i++) {
                        wordsCount.Add(line[i], 0);
                    }
                }
            }

            using (StreamReader reader = new StreamReader(textPath)) {
                while (!reader.EndOfStream) {
                    string[] words = reader.ReadLine().Split().ToArray();

                    for (int i = 0; i < words.Length; i++) {
                        if (wordsCount.ContainsKey(words[i])) wordsCount[words[i]]++;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath)) {
                foreach ((string word, int count) in wordsCount) {
                    writer.WriteLine($"{word} - {count}");
                }
            }
        }
        
    }
}
