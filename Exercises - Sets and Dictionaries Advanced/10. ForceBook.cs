using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

    public static void Main() {
        ReadData();
        PrintData();
    }

    private static void ReadData() {
        string line;
        while ((line = Console.ReadLine()) != "Lumpawaroo") {
            string[] data;
            if (line.Contains(" | ")) {
                data = line.Split(" | ");

                if (!forceBook.ContainsKey(data[0])) forceBook.Add(data[0], new List<string>());
                if (!forceBook.Values.Any(users => users.Contains(data[1]))) forceBook[data[0]].Add(data[1]);
            } 
            else if (line.Contains(" -> ")) {
                data = line.Split(" -> ");

                string currentSide = forceBook.FirstOrDefault(kvp => kvp.Value.Contains(data[0])).Key;
                if (currentSide != null) forceBook[currentSide].Remove(data[0]);
                if (!forceBook.ContainsKey(data[1])) forceBook.Add(data[1], new List<string>());
                forceBook[data[1]].Add(data[0]);

                Console.WriteLine($"{data[0]} joins the {data[1]} side!");
            }
        }
    }

    private static void PrintData() {
        foreach (var (side, members) in forceBook.OrderByDescending(c => c.Value.Count).ThenBy(n => n.Key)) {
            if (members.Count > 0) {
                Console.WriteLine($"Side: {side}, Members: {members.Count}");

                foreach (var member in members.OrderBy(n => n)) {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
