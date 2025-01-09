using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static long[][] matrix;

    static void Main() {
        int n = int.Parse(Console.ReadLine());
        matrix = new long[n][];
        
        FillMatrix(n);
        
        PrintMatrix();
    }

    private static void FillMatrix(int n) {
        for (int i = 0; i < n; i++) {
            matrix[i] = new long[i + 1];
            matrix[i][0] = 1;
            matrix[i][i] = 1;

            for (int j = 1; j < i; j++) {
                matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
            }
        }
    }
    
    private static void PrintMatrix() {
        foreach (long[] row in matrix) {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

