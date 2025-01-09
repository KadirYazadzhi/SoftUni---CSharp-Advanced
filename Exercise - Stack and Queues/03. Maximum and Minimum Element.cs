using System;
using System.Collections.Generic;

class Program {
    private static Stack<int> stack = new Stack<int>();
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());

        ReadCommands(n);
    }

    private static void ReadCommands(int n) {
        for (int i = 0; i < n; i++) {
            List<int> commands = Console.ReadLine().Split().Select(int.Parse).ToList();

            switch (commands[0]) {
                case 1:
                    stack.Push(commands[1]);
                    break;
                case 2:
                    stack.Pop();
                    break;
                case 3:
                    if (Empty()) break;
                    Console.WriteLine(stack.Max());
                    break;
                case 4:
                    if (Empty()) break;
                    Console.WriteLine(stack.Min());
                    break;
            }
        }
        
        Console.WriteLine(string.Join(", ", stack));
    }

    private static bool Empty() {
        return stack.Count == 0;
    }
}
