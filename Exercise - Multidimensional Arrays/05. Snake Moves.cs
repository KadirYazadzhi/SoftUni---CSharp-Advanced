using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program {
    private static char[,] matrix;
    
    static void Main() {
        string[] dimensions = Console.ReadLine().Split().ToArray();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        
        string snake = Console.ReadLine();

        matrix = new char[rows, cols];
        
        SnakeMove(rows, cols, snake);
        PrintMatrix(rows, cols);
    }

    private static void SnakeMove(int row, int col, string snake) {
        int snakeIndex = 0;
        
        for (int i = 0; i < row; i++) {
            if (i % 2 == 0) {
                for (int j = 0; j < col; j++) {
                    if (snake.Length - 1 < snakeIndex) snakeIndex = 0;
                
                    matrix[i, j] = snake[snakeIndex++];
                }
            }
            else {
                for (int j = col - 1; j >= 0; j--) {
                    if (snake.Length - 1 < snakeIndex) snakeIndex = 0;
                
                    matrix[i, j] = snake[snakeIndex++];
                }
            }

        }
    }

    private static void PrintMatrix(int rows, int cols) {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Console.Write(matrix[i, j]);
            }
            
            Console.WriteLine();
        }
    }
}
