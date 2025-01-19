using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FolderSize {
    public class FolderSize {
        static void Main(string[] args) {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath) {
            long totalBytes = CalculateFolderSize(folderPath);
            
            decimal totalSizeInKilobytes = totalBytes / 1024.0M;

            using (StreamWriter writer = new StreamWriter(outputFilePath)) {
                writer.WriteLine($"{totalSizeInKilobytes} KB");
            }
        }

        public static long CalculateFolderSize(string folderPath) {
            long totalBytes = 0;
            
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files) {
                FileInfo fileInfo = new FileInfo(file);
                totalBytes += fileInfo.Length;
            }
            
            string[] folders = Directory.GetDirectories(folderPath);
            foreach (string folder in folders) {
                totalBytes += CalculateFolderSize(folder);
            }
            
            return totalBytes;
        }
    }
}
