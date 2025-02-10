using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple {
    public class StartUp {
        static void Main() {
            string[] firstInput = Console.ReadLine().Split(' ', 3);
            var tuple1 = new Tuple<string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2]);
        
            string[] secondInput = Console.ReadLine().Split();
            var tuple2 = new Tuple<string, int>(secondInput[0], int.Parse(secondInput[1]));
        
            string[] thirdInput = Console.ReadLine().Split();
            var tuple3 = new Tuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));
        
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
