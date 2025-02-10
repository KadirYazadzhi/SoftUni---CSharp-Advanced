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
            Swap();
            PrintData();
        }

        private static void ReadData() {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }
        }

        private static void Swap() {
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            (boxes[indexes[0]], boxes[indexes[1]]) = (boxes[indexes[1]], boxes[indexes[0]]);
        }

        private static void PrintData() {
            foreach (Box<int> box in boxes) {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
