using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy {
    class StartUp {
        static void Main() {
            IEnumerable<int> stones = Console.ReadLine().Split(", ").Select(int.Parse);
            
            Console.WriteLine(string.Join(", ", new Lake(stones)));
        }
    }
}