using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBox {
    public class StartUp {
        static void Main() {
            double n = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++) {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }
            
            double element = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CountGreaterThan(element));
        }
    }
}
