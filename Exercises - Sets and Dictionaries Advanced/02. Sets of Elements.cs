using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static HashSet<int> setOfElementsOne = new HashSet<int>();
    private static HashSet<int> setOfElementsTwo = new HashSet<int>();

    public static void Main(string[] args) {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        ReadData(numbers[0], numbers[1]);
        FindRepeatedElements();
    }

    private static void ReadData(int n, int m) {
        for (int i = 0; i < n; i++) {
            setOfElementsOne.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 0; i < m; i++) {
            setOfElementsTwo.Add(int.Parse(Console.ReadLine()));
        }
    }

    private static void FindRepeatedElements() {
        List<int> numbers = new List<int>();

        foreach (int num in setOfElementsOne) {
            if (setOfElementsTwo.Contains(num)) numbers.Add(num);
        }
        
        Console.WriteLine(string.Join(" ", numbers));
    }
}

