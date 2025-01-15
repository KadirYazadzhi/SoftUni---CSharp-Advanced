using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static HashSet<string> parking = new HashSet<string>();

    public static void Main(string[] args) {
        ReadData();
        WriteData();
    }

    private static void ReadData() {
        string line;
        while ((line = Console.ReadLine()) != "END") {
            string[] commands = line.Split(", ").ToArray();

            switch (commands[0].ToUpper()) {
                case "IN":
                    parking.Add(commands[1].ToUpper());
                    break;
                case "OUT":
                    parking.Remove(commands[1].ToUpper());
                    break;
            }
        }
    }

    private static void WriteData() {
        if (parking.Count == 0) {
            Console.WriteLine("Parking Lot is Empty");
        }
        else {
            foreach (string car in parking) {
                Console.WriteLine(car);
            }
        }
    }
}

