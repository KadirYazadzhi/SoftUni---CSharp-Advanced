using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ExtractSpecialBytes {
    public class ExtractSpecialBytes {
        static void Main() {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath) {
            HashSet<byte> bytes = new HashSet<byte>();
            using (StreamReader reader = new StreamReader(bytesFilePath)) {
                while (!reader.EndOfStream) {
                    bytes.Add(byte.Parse(reader.ReadLine()));
                }
            }

            List<byte> result = new List<byte>();
            using (StreamReader reader = new StreamReader(binaryFilePath)) {
                while (!reader.EndOfStream) {
                    if (bytes.Contains(byte.Parse(reader.ReadLine()))) result.Add(byte.Parse(reader.ReadLine()));
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath)) {
                for (int i = 0; i < result.Count; i++) {
                    writer.WriteLine($"{result[i]:X2}");
                }
            }
        }
    }
}
