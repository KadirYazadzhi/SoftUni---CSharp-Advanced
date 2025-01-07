using System;
using System.Collections.Generic;

class Program {
    private static Queue<string> customers = new Queue<string>();
    
    static void Main() {
        string customerName = null;
        while ((customerName = Console.ReadLine()) != "End") {
            if (customerName != "Paid") {
                customers.Enqueue(customerName);
                continue;
            }
            
            RemoveAndPrintCurrentCustomers();
        }
        
        Console.WriteLine($"{customers.Count} people remaining.");
    }

    private static void RemoveAndPrintCurrentCustomers() {
        int count = customers.Count;
        
        for (int i = 0; i < count; i++) {
            Console.WriteLine(customers.Dequeue());
        }
    }
}
