using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static List<double> numbers = new List<double>();

    public static void Main(string[] args) {
        numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
        PrintLargestNumber();
    }

    private static void PrintLargestNumber() {
        numbers = numbers.OrderByDescending(x => x).ToList();

        if (numbers.Count < 3) {
            Console.WriteLine(string.Join(" ", numbers));
            return;
        }
        
        for (int i = 0; i < 3; i++) {
            Console.Write($"{numbers[i]} ");
        }
    }
}

