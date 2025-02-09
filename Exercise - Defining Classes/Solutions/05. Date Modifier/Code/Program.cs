using System;
using System.Linq;
using System.Globalization;

namespace  DefiningClasses {
    public class StartUp {
        public static void Main() {
            DateReader();
        }

        public static void DateReader() {
            Console.WriteLine(DateModifier.CalculateDifference(Console.ReadLine(), Console.ReadLine()));
        }
    }
}
