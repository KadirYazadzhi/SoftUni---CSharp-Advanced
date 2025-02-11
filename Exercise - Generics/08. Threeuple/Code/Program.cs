using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threeuple {
    public class StartUp {
        static void Main() {
            string[] firstInput = Console.ReadLine().Split(' ', 4);
            var threeuple1 = new Threeuple<string, string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2], firstInput[3]);
        
            string[] secondInput = Console.ReadLine().Split();
            var threeuple2 = new Threeuple<string, int, bool>(secondInput[0], int.Parse(secondInput[1]), secondInput[2].ToLower() == "drunk");
        
            string[] thirdInput = Console.ReadLine().Split();
            var threeuple3 = new Threeuple<string, double, string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);
        
            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);
        }
    }
}
