using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipAndExtract {
    public class ZipAndExtract {
        static void Main() {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath) {
            if (File.Exists(zipArchiveFilePath)) File.Delete(zipArchiveFilePath);
            
            using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create)) {
                string fileName = Path.GetFileName(inputFilePath);
                archive.CreateEntryFromFile(inputFilePath, fileName);
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath) {
            using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Read)) {
                ZipArchiveEntry entry = archive.GetEntry(fileName);
                
                if (entry is null) throw new InvalidOperationException("Invalid file name provided.");
                
                entry.ExtractToFile(outputFilePath, true);
            }
        }
    }
}
