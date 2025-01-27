using System;
using System.Collections.Generic;
using System.Linq;

public class Program {
    public static void Main() {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        Func<int[], int> PrintMin = x => x.Min();
        
        Console.WriteLine(PrintMin(numbers));
    }
}
