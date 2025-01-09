using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static int[,] matrix;
    
    static void Main() {
        int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        
        int rows = line[0];
        int cols = line[1];
        
        matrix = new int[rows, cols];
        
        ReadMatrix(rows, cols);
        
        Console.WriteLine(matrix.GetLength(0));
        Console.WriteLine(matrix.GetLength(1));
        Console.WriteLine(Sum());
    }

    private static int Sum() {
        int sum = 0; 
        
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                sum += matrix[i, j];
            }
        }
        
        return sum;
    }

    private static void ReadMatrix(int rows, int cols) {
        for (int i = 0; i < rows; i++) {
            int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            
            for (int j = 0; j < cols; j++) {
                matrix[i, j] = line[j];
            }
        }
    }
}
