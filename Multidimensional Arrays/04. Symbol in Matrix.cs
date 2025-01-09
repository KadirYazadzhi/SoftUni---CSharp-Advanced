using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static char[,] matrix;
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        
        matrix = new char[n, n];
        ReadMatrix(n);

        char element = char.Parse(Console.ReadLine());
        if (!FindElement(element)) {
            Console.WriteLine($"{element} does not occur in the matrix");
        }
    }

    private static bool FindElement(char ch) {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] == ch) {
                   Console.WriteLine($"({i}, {j})"); 
                   return true;
                }
            }
        }
        
        return false;
    }

    private static void ReadMatrix(int n) {
        for (int i = 0; i < n; i++) {
            char[] line = Console.ReadLine().ToCharArray();
            
            for (int j = 0; j < n; j++) {
                matrix[i, j] = line[j];
            }
        }
    }
}



