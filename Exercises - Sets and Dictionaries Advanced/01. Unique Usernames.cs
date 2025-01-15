using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static HashSet<string> usernames = new HashSet<string>();

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        
        ReadData(n);
        PrintUsers();
    }

    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            string line = Console.ReadLine();
            usernames.Add(line);
        }
    }

    private static void PrintUsers() {
        foreach (string names in usernames) {
            Console.WriteLine(names);
        }
    }
}

