using System;
using System.Linq;

class Solution {
    private static char[,] field;
    private static int totalCoals;
    private static int collectedCoals;

    public static void Main() {
        int fieldSize = int.Parse(Console.ReadLine());
        field = new char[fieldSize, fieldSize];
        
        ReadCommands(fieldSize);
    }

    private static void ReadCommands(int fieldSize) {
        string[] commands = Console.ReadLine().Split();

        int[] minerPosition = ReadField(fieldSize);
        totalCoals = CountTotalCoals();

        foreach (string command in commands) {
            int[] newPosition = MoveMiner(minerPosition, command);
            
            if (!IsValidPosition(newPosition[0], newPosition[1])) continue; 
            
            minerPosition[0] = newPosition[0];
            minerPosition[1] = newPosition[1];

            char currentCell = field[minerPosition[0], minerPosition[1]];

            if (currentCell == 'e') {
                Console.WriteLine($"Game over! ({minerPosition[0]}, {minerPosition[1]})");
                return;
            }

            if (currentCell == 'c') {
                collectedCoals++;
                field[minerPosition[0], minerPosition[1]] = '*'; 
                
                if (collectedCoals == totalCoals) {
                    Console.WriteLine($"You collected all coals! ({minerPosition[0]}, {minerPosition[1]})");
                    return;
                }
            }
        }

        Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({minerPosition[0]}, {minerPosition[1]})");
    }

    private static int[] ReadField(int fieldSize) {
        int[] minerPosition = new int[2];
        
        for (int row = 0; row < fieldSize; row++) {
            char[] rowElements = Console.ReadLine().Split().Select(char.Parse).ToArray();
            
            for (int col = 0; col < fieldSize; col++) {
                field[row, col] = rowElements[col];
                
                if (field[row, col] == 's') {
                    minerPosition[0] = row;
                    minerPosition[1] = col;
                }
            }
        }
        
        return minerPosition;
    }

    private static int CountTotalCoals() {
        int count = 0;
        
        foreach (char cell in field) {
            if (cell == 'c') count++;
        }
        
        return count;
    }

    private static int[] MoveMiner(int[] minerPosition, string direction) {
        int newRow = minerPosition[0];
        int newCol = minerPosition[1];

        switch (direction) {
            case "up": newRow--; break;
            case "down": newRow++; break;
            case "left": newCol--; break;
            case "right": newCol++; break;
        }

        return new int[] { newRow, newCol };
    }

    private static bool IsValidPosition(int row, int col) {
        return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
    }
}

