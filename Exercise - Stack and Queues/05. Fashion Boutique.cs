using System;
using System.Collections.Generic;

class Program {
    private static Stack<int> numbers = new Stack<int>();
    
    static void Main() {
        numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine(RacksCount(n));
    }

    private static int RacksCount(int capacity) {
        int n = capacity;
        int racks = 1;
        
        while (numbers.Count > 0) {
            if (n >= numbers.Peek()) {
                n -= numbers.Pop();
            }
            else {
                n = capacity;
                racks++;
            }
        }

        return racks;
    }
}
