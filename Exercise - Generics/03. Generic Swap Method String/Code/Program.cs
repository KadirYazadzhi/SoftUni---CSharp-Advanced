using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBox {
    public class StartUp {
        private static List<Box<string>> boxes = new List<Box<string>>();
        
        static void Main(string[] args) {
            ReadData();
            Swap();
            PrintData();
        }

        private static void ReadData() {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }
        }

        private static void Swap() {
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            (boxes[indexes[0]], boxes[indexes[1]]) = (boxes[indexes[1]], boxes[indexes[0]]);
        }

        private static void PrintData() {
            foreach (Box<string> box in boxes) {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
