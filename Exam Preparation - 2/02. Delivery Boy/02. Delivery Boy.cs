using System;
using System.Linq;

namespace DeliveryBoy {
    public class Program {
        public static void Main(string[] args) {
            int[] dimensions = ReadDimensions();
            string[,] field = InitializeField(dimensions, out int boyRow, out int boyCol, out int startRow, out int startCol);
            ProcessDelivery(field, ref boyRow, ref boyCol, startRow, startCol);
            PrintField(field, startRow, startCol, boyRow, boyCol);
        }

        private static int[] ReadDimensions() => Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        private static string[,] InitializeField(int[] dimensions, out int boyRow, out int boyCol, out int startRow, out int startCol) {
            string[,] field = new string[dimensions[0], dimensions[1]];
            boyRow = -1;
            boyCol = -1;
            startRow = -1;
            startCol = -1;

            for (int i = 0; i < field.GetLength(0); i++) {
                string newRow = Console.ReadLine();
                for (int j = 0; j < field.GetLength(1); j++) {
                    field[i, j] = newRow[j].ToString();

                    if (field[i, j] == "B") {
                        boyRow = i;
                        boyCol = j;
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            return field;
        }

        private static void ProcessDelivery(string[,] field, ref int boyRow, ref int boyCol, int startRow, int startCol) {
            bool hasLeft = false;

            while (true) {
                string command = Console.ReadLine();

                if (command == "left") {
                    if (!MoveLeft(field, ref boyRow, ref boyCol, ref hasLeft)) break;
                }
                else if (command == "right") {
                    if (!MoveRight(field, ref boyRow, ref boyCol, ref hasLeft)) break;
                }
                else if (command == "up") {
                    if (!MoveUp(field, ref boyRow, ref boyCol, ref hasLeft)) break;
                }
                else if (command == "down") {
                    if (!MoveDown(field, ref boyRow, ref boyCol, ref hasLeft)) break;
                }

                if (field[boyRow, boyCol] == "P") {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    field[boyRow, boyCol] = "R";
                    continue;
                }

                if (field[boyRow, boyCol] == "A") {
                    field[boyRow, boyCol] = "P";
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
            }

            if (hasLeft) field[startRow, startCol] = " ";
            else field[startRow, startCol] = "B";
        }

        private static bool MoveLeft(string[,] field, ref int boyRow, ref int boyCol, ref bool hasLeft) {
            if (boyCol > 0) {
                if (field[boyRow, boyCol - 1] == "*") return true;
                if (field[boyRow, boyCol] != "R") field[boyRow, boyCol] = ".";
                
                boyCol--;
            }
            else {
                if (field[boyRow, boyCol] == "-") field[boyRow, boyCol] = ".";
                
                hasLeft = true;
                Console.WriteLine("The delivery is late. Order is canceled.");
                return false;
            }

            return true;
        }

        private static bool MoveRight(string[,] field, ref int boyRow, ref int boyCol, ref bool hasLeft) {
            if (boyCol < field.GetLength(1) - 1) {
                if (field[boyRow, boyCol + 1] == "*") return true;
                if (field[boyRow, boyCol] != "R") field[boyRow, boyCol] = ".";
                
                boyCol++;
            }
            else {
                if (field[boyRow, boyCol] == "-") field[boyRow, boyCol] = ".";
                
                hasLeft = true;
                Console.WriteLine("The delivery is late. Order is canceled.");
                return false;
            }

            return true;
        }

        private static bool MoveUp(string[,] field, ref int boyRow, ref int boyCol, ref bool hasLeft) {
            if (boyRow > 0) {
                if (field[boyRow - 1, boyCol] == "*") return true;
                if (field[boyRow, boyCol] != "R") field[boyRow, boyCol] = ".";

                boyRow--;
            }
            else {
                if (field[boyRow, boyCol] == "-") field[boyRow, boyCol] = ".";
                
                hasLeft = true;
                Console.WriteLine("The delivery is late. Order is canceled.");
                return false;
            }

            return true;
        }

        private static bool MoveDown(string[,] field, ref int boyRow, ref int boyCol, ref bool hasLeft) {
            if (boyRow < field.GetLength(0) - 1) {
                if (field[boyRow + 1, boyCol] == "*") return true;

                if (field[boyRow, boyCol] != "R") field[boyRow, boyCol] = ".";
                
                boyRow++;
            }
            else {
                if (field[boyRow, boyCol] == "-") field[boyRow, boyCol] = ".";
                
                hasLeft = true;
                Console.WriteLine("The delivery is late. Order is canceled.");
                return false;
            }

            return true;
        }

        private static void PrintField(string[,] field, int startRow, int startCol, int boyRow, int boyCol) {
            for (int i = 0; i < field.GetLength(0); i++) {
                for (int j = 0; j < field.GetLength(1); j++) {
                    Console.Write(field[i, j]);
                }
                
                Console.WriteLine();
            }
        }
    }
}
