using System;
using System.Collections.Generic;

class Program {
    private static Queue<string> queue = new Queue<string>();
    
    static void Main() {
        List<string> names = Console.ReadLine().Split().ToList();
        int n = int.Parse(Console.ReadLine());
        
        SetData(names);
        
        Play(n);
    }

    private static void SetData(List<string> names) {
        foreach (string name in names) {
            queue.Enqueue(name);
        }
    }

    private static void Play (int n) {
        int x = 0;
        
        while (queue.Count > 1) {
            string name = queue.Dequeue();

            x++;

            if (x == n) {
                Console.WriteLine($"Removed {name}");
                x = 0;
                continue;
            }
            
            queue.Enqueue(name);
        }
        
        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}
