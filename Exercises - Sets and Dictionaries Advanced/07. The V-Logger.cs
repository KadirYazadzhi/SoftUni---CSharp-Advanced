using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();
    
    public static void Main(string[] args) {
        ReadData();
        PrintVloggers();
    }

    private static void ReadData() {
        string line = null;
        while ((line = Console.ReadLine()) != "Statistics") {
            string[] data = line.Split().ToArray();

            switch (data[1]) {
                case "joined":
                    if (!vloggers.ContainsKey(data[0])) vloggers.Add(data[0], new Vlogger());
                    break;
                case "followed":
                    string vloggerName = data[0];
                    string followedName = data[2];
                    
                    if (vloggerName != followedName && vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(followedName)) {
                        if (!vloggers[vloggerName].Followings.Contains(followedName)) {
                            vloggers[vloggerName].Followings.Add(followedName);
                            vloggers[followedName].Followers.Add(vloggerName);
                        }
                    }
                    break;
            }
        }
    }

    private static void PrintVloggers() {
        Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
        
        var mostFamousVlogger = PrintFirstVlogger();
        
        var sortedVloggers = vloggers.Where(v => v.Key != mostFamousVlogger.Key).OrderByDescending(v => v.Value.Followers.Count).ThenBy(v => v.Value.Followings.Count).ToList();
        int index = 2;
        foreach (var vlogger in sortedVloggers) {
            Console.WriteLine($"{index}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Followings.Count} following");
            index++;
        }
    }

    private static KeyValuePair<string, Vlogger> PrintFirstVlogger() {
        KeyValuePair<string, Vlogger> mostFamousVlogger = vloggers.OrderByDescending(v => v.Value.Followers.Count).ThenBy(v => v.Value.Followings.Count).First();
        Console.WriteLine($"1. {mostFamousVlogger.Key} : {mostFamousVlogger.Value.Followers.Count} followers, {mostFamousVlogger.Value.Followings.Count} following");
        foreach (var follower in mostFamousVlogger.Value.Followers.OrderBy(f => f)) {
            Console.WriteLine($"*  {follower}");
        }
        
        return mostFamousVlogger;
    }
}

class Vlogger {
    public List<string> Followers { get; set; } = new List<string>();
    public List<string> Followings { get; set; } = new List<string>();
}

