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
        Console.WriteLine(Sum());
    }

    private static int Sum() {
        int sum = 0;
        
        for (int i = 0; i < matrix.GetLength(1); i++) {
            sum += matrix[i, i];
        }
        
        return sum;
    }

    private static void ReadMatrix(int n) {
        for (int i = 0; i < n; i++) {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int j = 0; j < n; j++) {
                matrix[i, j] = line[j];
            }
        }
    }
}


