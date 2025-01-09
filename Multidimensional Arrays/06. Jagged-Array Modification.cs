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

        ReadCommands();
        PrintMatrix(n);
    } 

    private static void ReadMatrix(int n) {
        for (int i = 0; i < n; i++) {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int j = 0; j < n; j++) {
                matrix[i, j] = line[j];
            }
        }
    }

    private static void ReadCommands() {
        string line = null;
        while ((line = Console.ReadLine()) != "END") {
            string[] commands = line.Split().ToArray();

            if (!CheckCoordinates(int.Parse(commands[1]), int.Parse(commands[2]))) {
                Console.WriteLine("Invalid coordinates");
                continue;
            }
        
            switch (commands[0]) {
                case "Add":
                    matrix[int.Parse(commands[1]), int.Parse(commands[2])] += int.Parse(commands[3]);
                    break;
                case "Subtract":
                    matrix[int.Parse(commands[1]), int.Parse(commands[2])] -= int.Parse(commands[3]);
                    break;
            }
        }
    }
    
    private static void PrintMatrix(int n) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write(matrix[i, j] + " ");
            }
            
            Console.WriteLine();
        }
    }

    private static bool CheckCoordinates(int row, int col) {
        return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
    }
}

