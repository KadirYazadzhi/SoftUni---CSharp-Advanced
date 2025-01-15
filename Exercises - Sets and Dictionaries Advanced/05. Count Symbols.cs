using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<char, int> symbols = new Dictionary<char, int>();

    public static void Main(string[] args) {
        ReadData();
        PrintEvenTimesNumbers();
    }

    private static void ReadData() {
        char[] characters = Console.ReadLine().ToCharArray();
        
        for (int i = 0; i < characters.Length; i++) {
            if (symbols.ContainsKey(characters[i])) symbols[characters[i]]++;
            else symbols.Add(characters[i], 1);
        }
    }

    private static void PrintEvenTimesNumbers() {
        foreach ((char symbol, int count) in symbols.OrderBy(x => x.Key)) {
            Console.WriteLine($"{symbol}: {count} time/s");
        }
    }
}

