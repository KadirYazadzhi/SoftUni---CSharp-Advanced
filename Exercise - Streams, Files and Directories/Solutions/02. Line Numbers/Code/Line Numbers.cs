using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LineNumbers {
    public class LineNumbers {
        static void Main() {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath) {
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++) {
                lines[i] = ProcessLine(i + 1, lines[i]);
            }
            
            File.WriteAllLines(outputFilePath, lines);
        }

        public static string ProcessLine(int index, string line) {
            int lettersCount = 0, punctuationCount = 0;

            foreach (char symbol in line) {
                if (char.IsLetterOrDigit(symbol)) lettersCount++;
                else if (char.IsPunctuation(symbol)) punctuationCount++;
            }
            
            return $"Line {index}: {line} ({lettersCount})({punctuationCount})";
        }
    }
}
