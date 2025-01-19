using System;
using System.IO;

namespace LineNumbers {
    public class LineNumbers {
        static void Main(string[] args) {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputPath, string outputPath) {
            using (StreamReader reader = new StreamReader(inputPath)) {
                int number = 0;

                using (StreamWriter writer = new StreamWriter(outputPath)) {
                    while (!reader.EndOfStream) {
                        writer.WriteLine($"{++number}. {reader.ReadLine()}");
                    }
                }
            }
        }
    }
}
