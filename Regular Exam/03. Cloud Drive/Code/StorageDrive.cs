namespace CloudDrive;

 public class StorageDrive {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<File> Files { get; set; }

        public StorageDrive(string name, int capacity) {
            Name = name;
            Capacity = capacity;
            Files = new List<File>();
        }

        public void AddFile(File file) {
            bool fileExists = Files.Any(f => f.Name == file.Name && f.Extension == file.Extension);
            if (fileExists) return;
            
            int totalSize = Files.Sum(f => f.Size) + file.Size;
            if (totalSize > Capacity) return; 

            Files.Add(file);
        }

        public bool DeleteFile(string name, string extension) {
            File fileToRemove = Files.FirstOrDefault(f => f.Name == name && f.Extension == extension);
           
            if (fileToRemove != null) {
                Files.Remove(fileToRemove);
                return true;
            }
            
            return false;
        }

        public File GetLargestFile() {
            return Files.OrderByDescending(f => f.Size).First();
        }

        public string GetFileDetails(string name, string extension) {
            File file = Files.FirstOrDefault(f => f.Name == name && f.Extension == extension);
            
            if (file != null) {
                return file.ToString();
            }
            
            return "File not found!";
        }

        public int GetFilesCount() {
            return Files.Count;
        }

        public List<File> GetFilesByType(string extension) {
            return Files.Where(f => f.Extension == extension).OrderBy(f => f.Size).ToList();
        }

        public string StorageReport() {
            var orderedFiles = Files.OrderBy(f => f.Size).ToList();
            string report = $"Storage Drive: {Name}\n";
            
            foreach (var file in orderedFiles) {
                report += file.ToString() + "\n";
            }
            
            return report.Trim();
        }
    }