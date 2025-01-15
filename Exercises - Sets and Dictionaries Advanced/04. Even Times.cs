using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<int, int> numbers = new Dictionary<int, int>();

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        
        ReadData(n);
        PrintEvenTimesNumbers();
    }

    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            int  num = int.Parse(Console.ReadLine());

            if (numbers.ContainsKey(num)) numbers[num]++;
            else numbers.Add(num, 1);
        }
    }

    private static void PrintEvenTimesNumbers() {
        foreach ((int num, int count) in numbers) {
            if (count % 2 == 0) Console.WriteLine(num);
        }
    }
}

