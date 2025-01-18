using System;
using System.Linq;
using System.Reflection.Metadata;

class Program {
    private static Dictionary<string, string> contestsMap = new Dictionary<string, string>();
    private static Dictionary<string, Dictionary<string, int>> submissionsMap = new Dictionary<string, Dictionary<string, int>>();
    
    public static void Main() {
        ReadContests();
        ReadSubmissions();
        PrintUsers();
    }

    private static void ReadContests() {
        string input;
        while ((input = Console.ReadLine()) != "end of contests") {
            string[] data = input.Split(":").ToArray();
            
            contestsMap[data[0]] = data[1];
        }
    }

    private static void ReadSubmissions() {
        string input;
        while ((input = Console.ReadLine()) != "end of submissions") {
            string[] data = input.Split("=>").ToArray();

            if (contestsMap.ContainsKey(data[0]) && contestsMap[data[0]] == data[1]) {
                if (!submissionsMap.ContainsKey(data[2])) {
                    submissionsMap[data[2]] = new Dictionary<string, int>();
                }
                if (!submissionsMap[data[2]].ContainsKey(data[0])) {
                    submissionsMap[data[2]][data[0]] = 0;
                }
                if (int.Parse(data[3]) > submissionsMap[data[2]][data[0]]) {
                    submissionsMap[data[2]][data[0]] = int.Parse(data[3]);
                }
            }
        }
    }


    private static void PrintUsers() {
        (string username, int score) bestStudents = FindBestStudent();
        Console.WriteLine($"Best candidate is {bestStudents.username} with total {bestStudents.score} points.");
        
        Console.WriteLine("Ranking:");
        foreach (var (username, contestResultMap) in submissionsMap.OrderBy(x => x.Key)) {
            Console.WriteLine(username);

            foreach (var (contest, point) in contestResultMap.OrderByDescending(x => x.Value)) {
                Console.WriteLine($"#  {contest} -> {point}");
            }
        }
    }

    private static (string username, int score) FindBestStudent() {
        int maxScore = 0;
        string bestStudent = string.Empty;

        foreach (var (username, contestsResultMap) in submissionsMap) {
            int currentScore = contestsResultMap.Values.Sum();

            if (currentScore > maxScore) {
                maxScore = currentScore;
                bestStudent = username;
            }
        }
        
        return (bestStudent, maxScore);
    }
}
