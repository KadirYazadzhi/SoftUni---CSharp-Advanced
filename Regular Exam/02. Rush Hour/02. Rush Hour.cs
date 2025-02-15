using System;
using System.Linq;

class RushHour {
    static void Main() {
        var dimensions = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int N = int.Parse(dimensions[0]);
        int M = int.Parse(dimensions[1]);
        
        char[][] grid = new char[N][];
        int vehicleRow = -1, vehicleCol = -1;
        
        for (int i = 0; i < N; i++) {
            grid[i] = Console.ReadLine().ToCharArray();
            for (int j = 0; j < M; j++) {
                if (grid[i][j] == 'V') {
                    vehicleRow = i;
                    vehicleCol = j;
                }
            }
        }

        int trafficJams = 0;
        bool deliveryCompleted = false;
        int initialRow = vehicleRow, initialCol = vehicleCol;
        
        while (true) {
            string command = Console.ReadLine();
            if (command == null) break;

            int newRow = vehicleRow, newCol = vehicleCol;

            switch (command) {
                case "up": newRow--; break;
                case "down": newRow++; break;
                case "left": newCol--; break;
                case "right": newCol++; break;
            }
            
            if (newRow < 0 || newRow >= N || newCol < 0 || newCol >= M) continue; 
            
            if (grid[newRow][newCol] == 'X') {
                trafficJams++;
                grid[newRow][newCol] = '*'; 
                if (trafficJams >= 3) {
                    for (int i = 0; i < N; i++) {
                        for (int j = 0; j < M; j++) {
                            if (grid[i][j] == 'D') grid[i][j] = '*';
                        }
                    }
                    Console.WriteLine("Delivery failed, too many traffic jams!");
                    PrintGrid(grid);
                    return;
                }
                
                continue; 
            }
            
            grid[vehicleRow][vehicleCol] = '*';
            vehicleRow = newRow;
            vehicleCol = newCol;
            
            if (grid[vehicleRow][vehicleCol] == 'D') {
                deliveryCompleted = true;
                grid[vehicleRow][vehicleCol] = 'D'; 
                grid[initialRow][initialCol] = 'V'; 
                
                Console.WriteLine("Delivery completed!");
                PrintGrid(grid);
                
                return;
            }

            grid[vehicleRow][vehicleCol] = 'V'; 
        }
        
        if (!deliveryCompleted) {
            Console.WriteLine("Delivery failed, too many traffic jams!");
            PrintGrid(grid);
        }
    }

    static void PrintGrid(char[][] grid) {
        foreach (var row in grid) {
            Console.WriteLine(new string(row));
        }
    }
}
