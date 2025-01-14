using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<double, int> counts = new Dictionary<double, int>();

    public static void Main(string[] args) {
        ReadData();
        PrintCounts();
    }
    
    private static void ReadData() {
        double[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

        for (int i = 0; i < numbers.Length; i++) {
            if (counts.ContainsKey(numbers[i])) counts[numbers[i]]++;
            else counts.Add(numbers[i], 1);
        }
    }

    private static void PrintCounts() {
        foreach ((double number, int count) in counts) {
            Console.WriteLine($"{number} - {count} times");
        }
    }
}

