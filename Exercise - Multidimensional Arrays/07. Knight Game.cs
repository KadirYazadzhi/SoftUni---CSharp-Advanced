using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program {
    private static char[,] matrix;
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        matrix = new char[n, n];
        
        ReadMatrix(n);
       
        Console.WriteLine(RemoveKnight(n));
    }

    private static void ReadMatrix(int n) {
        for (int i = 0; i < n; i++) {
            List<char> characters = Console.ReadLine().ToCharArray().ToList();
            
            for (int j = 0; j < n; j++) {
                matrix[i, j] = characters[j];
            }
        }
    }

    private static int RemoveKnight(int n) {
        int removedKnights = 0;

        while (true) {
            int maxAttacks = 0;
            int knightRow = -1;
            int knightCol = -1;

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (matrix[i, j] == 'K' && CountAttacks(i, j) > maxAttacks) {
                        maxAttacks = CountAttacks(i, j);
                        knightRow = i;
                        knightCol = j;
                    }
                }
            }
            
            if (maxAttacks == 0) break;
            
            matrix[knightRow, knightCol] = '0';
            removedKnights++;
        }
        
        return removedKnights;
    }


    private static int CountAttacks(int row, int col) {
        int attacks = 0;
        int[,] moves = {
            { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 },
            { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }
        };

        for (int i = 0; i < moves.GetLength(0); i++) {
            int newRow = row + moves[i, 0];
            int newCol = col + moves[i, 1];
            if (ValidateIndexes(newRow, newCol) && matrix[newRow, newCol] == 'K') {
                attacks++;
            }
        }

        return attacks;
    }


    private static bool ValidateIndexes(int rows, int cols) {
        return rows >= 0 && cols >= 0 && rows < matrix.GetLength(0) && cols < matrix.GetLength(1);
    }
}
