using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBox {
    public class StartUp {
        private static List<Box<int>> boxes = new List<Box<int>>();
        
        static void Main(string[] args) {
            ReadData();
            PrintData();
        }

        private static void ReadData() {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                int value = int.Parse(Console.ReadLine());
                Type type = value.GetType();
                
                Box<int> box = new Box<int>(value, type);
                boxes.Add(box);
            }
        }

        private static void PrintData() {
            foreach (Box<int> box in boxes) {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
