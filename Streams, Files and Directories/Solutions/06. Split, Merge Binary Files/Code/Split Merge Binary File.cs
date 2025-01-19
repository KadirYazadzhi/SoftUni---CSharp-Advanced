using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SplitMergeBinaryFile {
    public class SplitMergeBinaryFile {
        static void Main() {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath) {
            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read)) {
                using (FileStream writerOne = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write)) {
                    using (FileStream writerTwo = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write)) {
                        long totalBytes = reader.Length;
                        long partOneSize = (totalBytes + 1) / 2; 
                        long partTwoSize = totalBytes / 2;
                        
                        CopyBytes(reader, writerOne, partOneSize);
                        
                        CopyBytes(reader, writerTwo, partTwoSize);

                    }
                }
            }
        }

        public static void CopyBytes(FileStream reader, FileStream writerOne, long partOneSize) {
            byte[] buffer = new byte[4096];
            long remaining = partOneSize;

            while (remaining > 0) {
                int bytesRead = reader.Read(buffer, 0, (int)Math.Min(buffer.Length, partOneSize));
                
                if (bytesRead == 0) break;
                
                writerOne.Write(buffer, 0, bytesRead);
                remaining -= bytesRead;
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath) {
            using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read)) {
                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read)) {
                    using (FileStream joined = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write)) {
                        CopyBytes(partOne, joined, partOne.Length);
                        
                        CopyBytes(partTwo, joined, partTwo.Length);
                    }
                }
            }
        }
    }
}
