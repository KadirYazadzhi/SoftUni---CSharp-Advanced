using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Stack<string> text = new Stack<string>();
    
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        
        ReadData(n);
    }

    private static void ReadData(int n) {
        text.Push("");

        for (int i = 0; i < n; i++) {
            string[] commands = Console.ReadLine().Split().ToArray();

            switch (int.Parse(commands[0])) {
                case 1:
                    text.Push(text.Peek() + commands[1]);
                    break;
                case 2:
                    text.Push(text.Peek().Substring(0, text.Peek().Length - int.Parse(commands[1])));
                    break;
                case 3:
                    int index = int.Parse(commands[1]) - 1; 
                    if (index < 0 || index >= text.Peek().Length) break;
                    Console.WriteLine(text.Peek()[index]);
                    break;
                case 4:
                    text.Pop();
                    break;
            }
        }
    }
}

