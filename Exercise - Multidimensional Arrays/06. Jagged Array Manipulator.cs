using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program {
    private static int[][] matrix;
    
    static void Main() {
        int rows = int.Parse(Console.ReadLine());
        matrix = new int[rows][];
        
        ReadMatrix(rows);
        AnalyzeMatrix(rows);
        
        ReadCommand();
    }

    private static void ReadMatrix(int rows) {
        for (int i = 0; i < rows; i++) {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            matrix[i] = new int[numbers.Count]; 
            
            for (int j = 0; j < numbers.Count; j++) {
                matrix[i][j] = numbers[j];
            }
        }
    }

    private static void AnalyzeMatrix(int rows) {
        for (int i = 0; i < rows - 1; i++) {
            if (matrix[i].Length == matrix[i + 1].Length) {
                MultiplyOrDivideNumbers(i, "multiply");
                MultiplyOrDivideNumbers(i + 1, "multiply");
            }
            else {
                MultiplyOrDivideNumbers(i, "divide");
                MultiplyOrDivideNumbers(i + 1, "divide");
            }
        }
    }

    private static void MultiplyOrDivideNumbers(int rows, string type) {
        if (type == "divide") {
            for (int i = 0; i < matrix[rows].Length; i++) {
                matrix[rows][i] /= 2;
            }
        }
        else if (type == "multiply") {
            for (int i = 0; i < matrix[rows].Length; i++) {
                matrix[rows][i] *= 2;
            }
        }
    }

    private static void ReadCommand() {
        string line = null;
        while ((line = Console.ReadLine()) != "End") {
            string[] commands = line.Split().ToArray();

            if (!ValidateIndexes(int.Parse(commands[1]), int.Parse(commands[2]))) continue;
            
            switch (commands[0]) {
                case "Add":
                    matrix[int.Parse(commands[1])][int.Parse(commands[2])] += int.Parse(commands[3]);
                    break;
                case "Subtract":
                    matrix[int.Parse(commands[1])][int.Parse(commands[2])] -= int.Parse(commands[3]);
                    break;
            }
        }
        
        PrintMatrix();
    }

    private static bool ValidateIndexes(int rows, int cols) {
        if (rows < 0 || cols < 0 || rows >= matrix.Length) return false;
        if (cols >= matrix[rows].Length) return false;
        
        return true;
    }

    private static void PrintMatrix() {
        for (int i = 0; i < matrix.Length; i++) {
            for (int j = 0; j < matrix[i].Length; j++) {
                Console.Write($"{matrix[i][j]} ");
            }
            
            Console.WriteLine();
        }
    }

}
