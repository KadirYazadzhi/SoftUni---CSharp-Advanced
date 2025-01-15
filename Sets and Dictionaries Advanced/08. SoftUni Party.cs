using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static HashSet<string> party = new HashSet<string>();

    public static void Main(string[] args) {
        DataManipulation("PARTY");
        DataManipulation("END");
        WriteData();
    }

    private static void DataManipulation(string command) {
        string line;
        while ((line = Console.ReadLine()) != command) {
            if (command == "PARTY") party.Add(line);
            else party.Remove(line);
        }
    }

    private static void WriteData() {
        Console.WriteLine(party.Count);
        
        foreach (string guest in party.OrderByDescending(g => char.IsDigit(g[0]))) {
            Console.WriteLine(guest);
        }
    }
}

