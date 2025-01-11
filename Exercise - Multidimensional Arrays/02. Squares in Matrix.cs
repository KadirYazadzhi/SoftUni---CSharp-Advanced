using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static char[,] matrix;
    
    static void Main() {
        string[] input = Console.ReadLine().Split().ToArray();
        
        int rows = int.Parse(input[0]);
        int cols = int.Parse(input[1]);
        
        matrix = new char[rows, cols];
        ReadMatrix(rows, cols);
        
        Console.WriteLine(FindSquares(rows, cols));
    }

    private static void ReadMatrix(int rows, int cols) {
        for (int i = 0; i < rows; i++) {
            List<char> characters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToList();
            
            for (int j = 0; j < cols; j++) {
                matrix[i, j] = characters[j];
            }
        }
    }

    private static int FindSquares(int rows, int cols) {
        int numberOfSquares = 0;
        
        for (int i = 0; i < rows - 1; i++) {
            for (int j = 0; j < cols - 1; j++) {
                if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1]) {
                    numberOfSquares++;
                }
            }
        }
        
        return numberOfSquares;
    }
}
