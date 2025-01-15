using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static HashSet<string> periodicTable = new HashSet<string>();

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        
        ReadData(n);
        PrintData();
    }

    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            string[] data = Console.ReadLine().Split().ToArray();

            for (int j = 0; j < data.Length; j++) {
                periodicTable.Add(data[j]);
            }
        }
    }

    private static void PrintData() {
        periodicTable = periodicTable.OrderBy(x => x).ToHashSet();
        
        Console.WriteLine(string.Join(" ", periodicTable));
    }
}

