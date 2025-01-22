using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyDirectory {
    public class CopyDirectory {
        static void Main() {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath) {
            if (Directory.Exists(outputPath)) Directory.Delete(outputPath, true);
            
            Directory.CreateDirectory(outputPath);

            foreach (string pathToSourceFile in Directory.GetFiles(inputPath)) {
                string fileName = Path.GetFileName(pathToSourceFile);
                string pathToDestinationFile = Path.Combine(outputPath, fileName);
                
                File.Copy(pathToSourceFile, pathToDestinationFile);
            }
        }
    }
}
