using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        List<string> guests = Console.ReadLine().Split().ToList();

        string command;
        while ((command = Console.ReadLine()) != "Party!") {
            string[] tokens = command.Split();

            Predicate<string> predicate = GetPredicate(tokens[1], tokens[2]);

            if (tokens[0] == "Remove") {
                guests.RemoveAll(predicate);
            }
            else if (tokens[0] == "Double") {
                List<string> matchingGuests = guests.FindAll(predicate);
                foreach (var guest in matchingGuests) {
                    int index = guests.IndexOf(guest);
                    guests.Insert(index, guest);
                }
            }
        }

        if (guests.Any()) Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
        else Console.WriteLine("Nobody is going to the party!");
    }

    static Predicate<string> GetPredicate(string type, string value) {
        return type switch {
            "StartsWith" => name => name.StartsWith(value),
            "EndsWith" => name => name.EndsWith(value),
            "Length" => name => name.Length == int.Parse(value),
            _ => throw new ArgumentException("Invalid criteria type")
        };
    }
}
