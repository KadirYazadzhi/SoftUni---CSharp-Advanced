using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        List<string> invitations = Console.ReadLine().Split().ToList();
        Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
        
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "Print") {
            string[] tokens = command.Split(";");
            string action = tokens[0];
            string filterType = tokens[1];
            string filterParameter = tokens[2];

            string filterKey = $"{filterType};{filterParameter}";

            if (action == "Add filter") filters[filterKey] = GetPredicate(filterType, filterParameter);
            else if (action == "Remove filter") filters.Remove(filterKey);
        }

        foreach (var filter in filters.Values) {
            invitations = invitations.Where(name => !filter(name)).ToList();
        }
        
        Console.WriteLine(string.Join(" ", invitations));
    }

    static Predicate<string> GetPredicate(string type, string parameter) {
        return type switch {
            "Starts with" => name => name.StartsWith(parameter),
            "Ends with" => name => name.EndsWith(parameter),
            "Length" => name => name.Length == int.Parse(parameter),
            "Contains" => name => name.Contains(parameter),
            _ => throw new ArgumentException("Invalid filter type")
        };
    }
}
