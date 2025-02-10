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
            PrintData();
        }

        private static void ReadData() {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                string value = Console.ReadLine();
                Type type = value.GetType();
                
                Box<string> box = new Box<string>(value, type);
                boxes.Add(box);
            }
        }

        private static void PrintData() {
            foreach (Box<string> box in boxes) {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
