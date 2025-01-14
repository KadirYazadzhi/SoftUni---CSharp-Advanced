using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, Dictionary<string, List<string>>> countries = new Dictionary<string, Dictionary<string, List<string>>>();

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        
        ReadData(n);
        PrintCountries();
    }

    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (!countries.ContainsKey(data[0])) {
                countries.Add(data[0], new Dictionary<string, List<string>>());
            }
            
            if (countries[data[0]].ContainsKey(data[1])) {
                countries[data[0]][data[1]].Add(data[2]);
            }
            else {
                countries[data[0]].Add(data[1], new List<string> { data[2] });
            }
        }
    }

    private static void PrintCountries() {
        foreach ((string continent, Dictionary<string, List<string>> countriesData) in countries) {
            Console.WriteLine($"{continent}:");

            foreach ((string country, List<string> cities) in countriesData) {
                Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
            }
        }
    }
}

