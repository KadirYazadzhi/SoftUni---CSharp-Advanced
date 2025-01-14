using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        
        ReadData(n);
        PrintCounts();
    }
    
    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            string[] data = Console.ReadLine().Split();
            
            if (studentGrades.ContainsKey(data[0])) studentGrades[data[0]].Add(decimal.Parse(data[1]));
            else studentGrades.Add(data[0], new List<decimal> { decimal.Parse(data[1]) });
        }
    }

    private static void PrintCounts() {
        foreach ((string name, List<decimal> grades) in studentGrades) {
            Console.WriteLine($"{name} -> {string.Join(" ", grades.Select(grade => grade.ToString("F2")))} (avg: {grades.Average():F2})");
        }
    }
}

