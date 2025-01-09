using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static List<(int petrol, int distance)> petrolPumps = new List<(int petrol, int distance)>();
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        ReadData(n);
        
        Console.WriteLine(FindStartingRoute());
    }

    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            string[] input = Console.ReadLine().Split();
            petrolPumps.Add((int.Parse(input[0]), int.Parse(input[1])));
        }
    }

    private static int FindStartingRoute() {
        int currentBalance = 0;
        int start = 0;
        int totalBalance = 0;

        for (int i = 0; i < petrolPumps.Count; i++) {
            currentBalance += petrolPumps[i].petrol - petrolPumps[i].distance;
            totalBalance += petrolPumps[i].petrol - petrolPumps[i].distance;

            if (currentBalance < 0) {
                start = i + 1;
                currentBalance = 0;
            }
        }
        
        return totalBalance >= 0 ? start : -1;
    }
}

