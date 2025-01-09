using System;
using System.Collections.Generic;

class Program {
    private static Queue<int> orders = new Queue<int>();
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        
        orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        
        Serve(n);
    }

    private static void Serve(int n) {
        Console.WriteLine(orders.Max());

        while (orders.Count > 0) {
            if (n >= orders.Peek()) {
                n -= orders.Dequeue();
            }
            else {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                return;
            }
        }

        Console.WriteLine("Orders complete");
    }
}


