using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Queue<int> CupsCapacity = new Queue<int>();
    private static Stack<int> FilledBottles = new Stack<int>();
    
    static void Main() { 
        CupsCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        FilledBottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        
        Fill();
    }

    private static void Fill() {
        int litters = 0;
        
        while (CupsCapacity.Count > 0 && FilledBottles.Count > 0) {
            int remaining = FilledBottles.Pop() - CupsCapacity.Peek();

            while (remaining < 0) {
                remaining += FilledBottles.Pop();
            }
            
            CupsCapacity.Dequeue();
            litters += remaining;
        }

                    
        if (FilledBottles.Count == 0 && CupsCapacity.Count > 0) {
            Console.WriteLine($"Cups: {string.Join(" ", CupsCapacity)}");
        }
        else {
            Console.WriteLine($"Bottles: {string.Join(" ", FilledBottles)}");
        }
        
        Console.WriteLine($"Wasted litters of water: {litters}");
    }
}
