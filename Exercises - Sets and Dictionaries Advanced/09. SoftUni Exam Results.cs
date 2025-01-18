using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, Dictionary<string, int>> submissionsMap = new Dictionary<string, Dictionary<string, int>>();
    private static Dictionary<string, int> submissionCounts = new Dictionary<string, int>();
    private static HashSet<string> bannedUsers = new HashSet<string>();

    public static void Main() {
        ReadData();
        PrintData();
    }

    private static void ReadData() {
        string line;
        while ((line = Console.ReadLine()) != "exam finished") {
            string[] data = line.Split("-");
            string username = data[0];

            if (data[1] == "banned") {
                bannedUsers.Add(username);
            } 
            else {
                string language = data[1];
                int points = int.Parse(data[2]);
                
                if (!submissionsMap.ContainsKey(username)) submissionsMap[username] = new Dictionary<string, int>();
                if (!submissionsMap[username].ContainsKey(language) || submissionsMap[username][language] < points) submissionsMap[username][language] = points;
                if (!submissionCounts.ContainsKey(language)) submissionCounts[language] = 0;
                
                submissionCounts[language]++;
            }
        }
    }

    private static void PrintData() {
        Console.WriteLine("Results:");
        foreach (var (username, maxPoints) in submissionsMap
                     .Where(x => !bannedUsers.Contains(x.Key)) // Exclude banned users
                     .Select(x => (username: x.Key, maxPoints: x.Value.Values.Max()))
                     .OrderByDescending(x => x.maxPoints)
                     .ThenBy(x => x.username)) {
            Console.WriteLine($"{username} | {maxPoints}");
        }
        
        Console.WriteLine("Submissions:");
        foreach (var (language, count) in submissionCounts.OrderByDescending(x => x.Value).ThenBy(x => x.Key)) {
            Console.WriteLine($"{language} - {count}");
        }
    }
}

