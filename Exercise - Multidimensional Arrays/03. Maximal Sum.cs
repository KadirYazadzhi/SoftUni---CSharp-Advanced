using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program {
    private static int[,] matrix;
    
    static void Main() {
        string[] dimensions = Console.ReadLine().Split().ToArray();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        matrix = new int[rows, cols];
        
        ReadMatrix(rows, cols);
        int[] data = FindMaxSum(rows, cols);
        
        PrintResult(data[0], data[1], data[2]);
    }

    private static void ReadMatrix(int rows, int cols) {
        for (int i = 0; i < rows; i++) {
            var row = Console.ReadLine().Split();
            
            for (int j = 0; j < cols; j++) {
                matrix[i, j] = int.Parse(row[j]);
            }
        }
    }

    private static int[] FindMaxSum(int rows, int cols) {
        int maxSum = int.MinValue;
        int topLeftRow = 0, topLeftCol = 0;
        
        for (int i = 0; i < rows - 2; i++) {
            for (int j = 0; j < cols - 2; j++) {
                int currentSum = 0;
                for (int k = 0; k < 3; k++) {
                    for (int l = 0; l < 3; l++) {
                        currentSum += matrix[i + k, j + l];
                    }
                }
                
                if (currentSum > maxSum) {
                    maxSum = currentSum;
                    topLeftRow = i;
                    topLeftCol = j;
                }
            }
        }
        
        return new int[] { maxSum, topLeftRow, topLeftCol };
    }

    private static void PrintResult(int maxSum, int topLeftRow, int topLeftCol) {
        Console.WriteLine($"Sum = {maxSum}");
        
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                Console.Write($"{matrix[topLeftRow + i, topLeftCol + j]} ");
            }
            
            Console.WriteLine();
        }
    }
}
