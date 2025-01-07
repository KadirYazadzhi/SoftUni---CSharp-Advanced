using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Stack<int> nums = new Stack<int>();
    
    static void Main(string[] args) {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        AddToStack(numbers);
        
        string line = null;
        while ((line = Console.ReadLine().ToLower()) != "end") {
            string[] commands = line.Split();

            switch (commands[0]) {
                case "add":
                    AddNumbersToStack(commands);
                    break;
                case "remove":
                    RemoveNumbersFromStack(int.Parse(commands[1]));
                    break;
            }
        }

        // Or use {nums.Sum()} and remove method {SumNumbers}
        Console.WriteLine($"Sum: {SumNumbers()}");
    }

    private static void AddToStack(List<int> numbers) {
        foreach (int num in numbers) {
            nums.Push(num);
        }
    }

    private static void AddNumbersToStack(string[] commands) {
        nums.Push(int.Parse(commands[1]));
        nums.Push(int.Parse(commands[2]));
    }

    private static void RemoveNumbersFromStack(int n) {
        if (nums.Count < n) return;

        for (int i = 0; i < n; i++) {
            nums.Pop();
        }
    }

    private static int SumNumbers() {
        int sum = 0;
        
        foreach (int num in nums) {
            sum += num;
        }

        return sum;
    }
}
