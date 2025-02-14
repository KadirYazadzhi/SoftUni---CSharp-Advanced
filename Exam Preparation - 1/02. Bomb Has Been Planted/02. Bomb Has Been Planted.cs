using System;
using System.Collections.Generic;
using System.Linq;

public class Program {
    private static char[,] matrix;
    private static (int, int) bombPosition = (-1, -1);
    private static (int, int) counterTerroristPosition = (-1, -1);
    private static int time = 16;
    private static Dictionary<string, (int, int)> positions = new Dictionary<string, (int, int)> {
        { "up", (-1, 0) },
        { "down", (1, 0) },
        { "right", (0, 1) },
        { "left", (0, -1) },
    };
    
    public static void Main() {
        ReadMatrix();
        ReadCommands();
        PrintMatrix();
    }

    private static void ReadMatrix() {
        int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        matrix = new char[data[0], data[1]];

        for (int i = 0; i < data[0]; i++) {
            char[] characters = Console.ReadLine().ToCharArray();
            
            for (int j = 0; j < data[1]; j++) {
                matrix[i, j] = characters[j];

                if (characters[j] == 'B') bombPosition = (i, j);
                if (characters[j] == 'C') counterTerroristPosition = (i, j);
            }
        }
    }

    private static void ReadCommands() {
        while (time > 0) {
            string command = Console.ReadLine();
            
            if (command == "defuse") {
                if (counterTerroristPosition != bombPosition) {
                    time -= 2;
                    continue;
                }
                
                time -= 4;
                if (time >= 0) {
                    matrix[bombPosition.Item1, bombPosition.Item2] = 'D';
                    Console.WriteLine("Counter-terrorist wins!");
                    Console.WriteLine($"Bomb has been defused: {time} second/s remaining.");
                    return;
                } 
            
                matrix[bombPosition.Item1, bombPosition.Item2] = 'X';
                Console.WriteLine("Terrorists win!");
                Console.WriteLine("Bomb was not defused successfully!");
                Console.WriteLine($"Time needed: {Math.Abs(time)} second/s.");
            
                return;
            }
            
            if (positions.ContainsKey(command)) {
                (int row, int col) = positions[command];
                int newRow = counterTerroristPosition.Item1 + row;
                int newCol = counterTerroristPosition.Item2 + col;
                
                if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1)) {
                    counterTerroristPosition = (newRow, newCol);
                }
                
                time--;
                if (time < 0) {
                    Console.WriteLine("Terrorists win!");
                    Console.WriteLine("Bomb was not defused successfully!");
                    Console.WriteLine($"Time needed: {Math.Abs(time)} second/s.");
                    return;
                }
                
                if (matrix[counterTerroristPosition.Item1, counterTerroristPosition.Item2] == 'T') {
                    matrix[counterTerroristPosition.Item1, counterTerroristPosition.Item2] = '*';
                    Console.WriteLine("Terrorists win!");
                    return;
                }
            }
        }
        
        Console.WriteLine("Terrorists win!");
        Console.WriteLine("Bomb was not defused successfully!");
        Console.WriteLine($"Time needed: {Math.Abs(time)} second/s.");
    }

    private static void PrintMatrix() {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}

