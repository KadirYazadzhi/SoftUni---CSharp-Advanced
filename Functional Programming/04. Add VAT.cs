using System;
using System.Collections.Generic;
using System.Linq;

public class Program {
    public static void Main() {
        string[] numbers = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x * 1.20).Select(x => $"{x:F2}").ToArray();
        Console.WriteLine(string.Join("\n", numbers));
    }
}

