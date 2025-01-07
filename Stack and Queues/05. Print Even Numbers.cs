using System;
using System.Collections.Generic;

class Program {
    private static Queue<int> numbers = new Queue<int>();
    
    static void Main(string[] args) {
        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        AddEvenNumberToQueue(nums);
        
        Console.WriteLine(string.Join(", ", numbers));
    }

    private static void AddEvenNumberToQueue(List<int> nums) {
        foreach (int num in nums) {
            if (num % 2 == 0) numbers.Enqueue(num);
        }
    }
}
