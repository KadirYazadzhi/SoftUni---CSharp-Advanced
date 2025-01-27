using System;
using System.Collections.Generic;
using System.Linq;

public class Program {
    public static void Main() {
        Action<string> Print = name => Console.WriteLine($"Sir {name}");
        
        string[] names = Console.ReadLine().Split().ToArray(); 
        
        names.ToList().ForEach(Print);
    }
}

