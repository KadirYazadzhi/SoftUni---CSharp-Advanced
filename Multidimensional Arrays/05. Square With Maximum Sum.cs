using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static int[,] matrix;
    private static List<SumObject> max = new List<SumObject>();

    static void Main() {
        int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        
        matrix = new int[line[0], line[1]];
        ReadMatrix(line[0], line[1]);
        
        FindMaximumSum();
        
        SumObject maxSumObject = max.OrderByDescending(obj => obj.Sum).First();
        
        Console.WriteLine($"{maxSumObject.Numbers[0]} {maxSumObject.Numbers[1]}");
        Console.WriteLine($"{maxSumObject.Numbers[2]} {maxSumObject.Numbers[3]}");
        Console.WriteLine(maxSumObject.Sum);
    }

    private static void FindMaximumSum() {
        for (int row = 0; row < matrix.GetLength(0) - 1; row++) {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++) {
                int sum = 0;
                SumObject sumObject = new SumObject();
                
                sum += matrix[row, col];
                sumObject.Numbers.Add(matrix[row, col]);
                
                sum += matrix[row, col + 1];
                sumObject.Numbers.Add(matrix[row, col + 1]);
                
                sum += matrix[row + 1, col];
                sumObject.Numbers.Add(matrix[row + 1, col]);
                
                sum += matrix[row + 1, col + 1];
                sumObject.Numbers.Add(matrix[row + 1, col + 1]);

                sumObject.Sum = sum;
                max.Add(sumObject);
            }
        }
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

class SumObject {
    public int Sum;
    public List<int> Numbers = new List<int>();
}
