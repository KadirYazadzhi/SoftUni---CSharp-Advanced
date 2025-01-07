using System;
using System.Collections.Generic;

class Program {
    private static Stack<int> indexes = new Stack<int>();
    
    static void Main(string[] args) {
        string line = Console.ReadLine();
        FindBrackets(line);
    }

    private static void FindBrackets(string line) {
        for (int i = 0; i < line.Length; i++) {
            if (line[i] == '(') {
                indexes.Push(i);
            }
            else if (line[i] == ')') {
                PrintSubstring(line, i);
            }
        }
    }

    private static void PrintSubstring(string line, int endIndex) {
        int startIndex = indexes.Pop();
        
        string subExpression = line.Substring(startIndex, endIndex - startIndex + 1);
        Console.WriteLine(subExpression);
    }
}
