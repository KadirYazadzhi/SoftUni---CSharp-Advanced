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
        
        Swap(rows, cols);
    }

    private static void ReadMatrix(int rows, int cols) {
        for (int i = 0; i < rows; i++) {
            var row = Console.ReadLine().Split();
            
            for (int j = 0; j < cols; j++) {
                matrix[i, j] = int.Parse(row[j]);
            }
        }
    }

    private static void Swap(int rows, int cols) {
        string line = null;
        while ((line = Console.ReadLine()) != "END") {
            string[] commands = line.Split().ToArray();

            if (commands[0] != "swap" ||
                commands.Length != 5 ||
                int.Parse(commands[1]) > rows ||
                int.Parse(commands[1]) < 0 ||
                int.Parse(commands[2]) > cols ||
                int.Parse(commands[2]) < 0 ||
                int.Parse(commands[3]) > rows ||
                int.Parse(commands[3]) < 0 ||
                int.Parse(commands[4]) > cols ||
                int.Parse(commands[4]) < 0) {
                Console.WriteLine("Invalid input!");
                continue;
            }

            int temp = matrix[int.Parse(commands[1]), int.Parse(commands[2])];
            matrix[int.Parse(commands[1]), int.Parse(commands[2])] = matrix[int.Parse(commands[3]), int.Parse(commands[4])];
            matrix[int.Parse(commands[3]), int.Parse(commands[4])] = temp;
            
            PrintMatrix(rows, cols);
        }
    }

    private static void PrintMatrix(int rows, int cols) {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Console.Write($"{matrix[i, j]} ");
            }
            
            Console.WriteLine();
        }
    }
}
