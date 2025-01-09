using System;
using System.Collections.Generic;

class Program {
    private static Stack<int> stack = new Stack<int>();
    
    static void Main() {
        List<int> operationNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        ReadNumbers(numbers);
        
        MakeOperation(operationNumbers);
    }

    private static void ReadNumbers(List<int> numbers) {
        for (int i = 0; i < numbers.Count; i++) {
            stack.Push(numbers[i]);
        }
    }

    private static void MakeOperation(List<int> operationNumbers) {
        for (int i = 0; i < operationNumbers[1]; i++) {
            stack.Pop();
        }

        if (stack.Contains(operationNumbers[2])) {
            Console.WriteLine("true");
        }
        else if (stack.Count == 0) {
            Console.WriteLine(0);
        }
        else {
            Console.WriteLine(stack.Min());
        }
    }
}
