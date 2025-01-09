using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Stack<char> brackets = new Stack<char>();
    
    static void Main() {
       ReadData();

        if (brackets.Count == 0) {
            Console.WriteLine("YES");
        }
        else {
            Console.WriteLine("NO");
        }
    }

    private static void ReadData() {
        string line = Console.ReadLine();

        for (int i = 0; i < line.Length; i++) {
            if (line[i] == '(' || line[i] == '[' || line[i] == '{') {
                brackets.Push(line[i]);
            }
            else if (line[i] == ')' || line[i] == ']' || line[i] == '}') {
                if (!DeleteBrackets(line[i])) {
                    Console.WriteLine("NO");
                    Environment.Exit(0);
                }
            }
        }
    }

    private static bool DeleteBrackets(char bracketToDelete) {
        if (brackets.Count == 0) return false;

        char bracket = brackets.Peek();
        bool isMatching = false;

        switch (bracketToDelete) {
            case ')':
                isMatching = bracket == '('; 
                break;
            case ']':
                isMatching = bracket == '[';
                break;
            case '}':
                isMatching = bracket == '{';
                break;
        }

        if (isMatching) {
            brackets.Pop();
        }

        return isMatching;
    }
    
}



