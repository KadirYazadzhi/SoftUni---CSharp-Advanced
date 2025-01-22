using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal {
    public class DirectoryTraversal {
        static void Main() {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath) {
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();

            foreach (string file in Directory.GetFiles(inputFolderPath)) {
                FileInfo fileInfo = new FileInfo(file);
                
                if (!filesByExtension.ContainsKey(fileInfo.Extension)) filesByExtension[fileInfo.Extension] = new List<FileInfo>();
                
                filesByExtension[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder result = new StringBuilder();
            foreach (var (extension, fileInfo) in filesByExtension.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)) {
                result.AppendLine(extension);

                foreach (FileInfo info in fileInfo.OrderBy(x => x.Length)) {
                    result.AppendLine($"--{info.Name} - {info.Length / 1024m} kb");
                }
            }
            
            return result.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName) {
            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            string pathToOutput = pathToDesktop + reportFileName;
            
            File.WriteAllText(pathToOutput, textContent);
        }
    }
}
