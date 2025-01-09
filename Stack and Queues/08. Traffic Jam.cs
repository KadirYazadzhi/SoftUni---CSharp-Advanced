using System;
using System.Collections.Generic;

class Program {
    private static Queue<string> queue = new Queue<string>();
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        
        ReadData(n);
    }

    private static void ReadData(int n) {
        int count = 0;
        
        string line = null;
        while ((line = Console.ReadLine()) != "end") {
            if (line != "green") {
                queue.Enqueue(line);
                continue;
            }
            count += CarPass(n);
        }
        
        Console.WriteLine($"{count} cars passed the crossroads.");
    }

    private static int CarPass(int n) {
        int count = 0;
        
        while (queue.Count > 0 && n > 0) {
            string car = queue.Dequeue();
            Console.WriteLine($"{car} passed!");
            n--;
            count++;
        }
        
        return count;
    }

}
