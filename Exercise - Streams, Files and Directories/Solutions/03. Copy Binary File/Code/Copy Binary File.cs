using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CopyBinaryFile {
    public class CopyBinaryFile {
        static void Main() {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath) {
            using (FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read)) {
                using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write)) {
                    byte[] buffer = new byte[1024];

                    int readBytes;
                    while ((readBytes = inputStream.Read(buffer)) != 0) {
                        outputStream.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
