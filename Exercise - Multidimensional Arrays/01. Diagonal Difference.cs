using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static int[,] matrix;
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        matrix = new int[n, n];
        ReadMatrix(n);
        
        Console.WriteLine(FindDiagonalDifference(n));
    }

    private static void ReadMatrix(int n) {
        for (int i = 0; i < n; i++) {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int j = 0; j < n; j++) {
                matrix[i, j] = numbers[j];
            }
        }
    }

    private static int FindDiagonalDifference(int n) {
        int primarySum = 0;
        int secondarySum = 0;

        for (int i = 0; i < n; i++) {
            primarySum += matrix[i, i];
            secondarySum += matrix[i, n - i - 1];
        }
        
        return Math.Abs(primarySum - secondarySum);
    }
}
