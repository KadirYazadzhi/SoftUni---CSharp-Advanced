using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    private static int[,] matrix;
    
    public static void Main() {
        int n = int.Parse(Console.ReadLine());
        
        matrix = new int[n, n];
        
        ReadMatrix(n);
        BombsExplode();
        PrintMatrix();
    }

    private static void ReadMatrix(int n) {
        for (int i = 0; i < n; i++) {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int j = 0; j < n; j++) {
                matrix[i, j] = numbers[j];    
            }
        }
    }

    private static void BombsExplode() {
        string[] line = Console.ReadLine().Split().ToArray();

        for (int i = 0; i < line.Length; i++) {
            int[] data = line[i].Split(",").Select(int.Parse).ToArray();

            if (matrix[data[0], data[1]] > 0) {
                Explode(data[0], data[1]);
                matrix[data[0], data[1]] = 0;
            }
        }
        
        Console.WriteLine($"Alive cells: {CountAliveCells()}");
        Console.WriteLine($"Sum: {SumAliveCells()}");
    }

    private static void Explode(int row, int col) {
        int[,] directions = {
            { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 }, 
            { -1, 1 }, { -1, -1 }, { 1, 1 }, { 1, -1 }
        };

        for (int i = 0; i < directions.GetLength(0); i++) {
            int newRow = row + directions[i, 0];
            int newCol = col + directions[i, 1];

            if (ValidateIndexes(newRow, newCol) && matrix[newRow, newCol] > 0) {
                matrix[newRow, newCol] -= matrix[row, col];
            }
        }
    }

    private static int SumAliveCells() {
        int sum = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] > 0) sum += matrix[i, j];
            }
        }
        
        return sum;
    }

    private static void PrintMatrix() {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                Console.Write($"{matrix[i, j]} ");
            }
            
            Console.WriteLine();
        }
    }

    private static int CountAliveCells() {
        int aliveCells = 0;
        
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] > 0) aliveCells++;
            }
        }
        
        return aliveCells;
    }

    private static bool ValidateIndexes(int row, int col) {
        return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
    }
}

