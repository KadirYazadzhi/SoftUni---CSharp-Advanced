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
        Sum();
    }

    private static void Sum() {
        for (int i = 0; i < matrix.GetLength(1); i++) {
            int sum = 0;
            
            for (int j = 0; j < matrix.GetLength(0); j++) {
                sum += matrix[j, i];
            }

            Console.WriteLine(sum);
        }
    }

    private static void ReadMatrix(int rows, int cols) {
        for (int i = 0; i < rows; i++) {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int j = 0; j < cols; j++) {
                matrix[i, j] = line[j];
            }
        }
    }
}

