using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Stack<string> nums = new Stack<string>();
    
    static void Main(string[] args) {
        List<string> data = Console.ReadLine().Split().ToList();
        
        AddToStack(data);
        
        Console.WriteLine(SumsNumbers());
    }

    private static void AddToStack(List<string> data) {
        foreach (string token in data) {
            nums.Push(token);
        }
    }

    private static int SumsNumbers() {
        int sum = 0;

        while (nums.Count > 1) {
            int num = int.Parse(nums.Pop());
            string expression = nums.Pop();

            switch (expression) {
                case "-":
                    sum -= num;
                    break;
                case "+":
                    sum += num;
                    break;
            }
        }
        
        if (nums.Count > 0) {
            sum += int.Parse(nums.Pop());
        }

        return sum;
    }
}
