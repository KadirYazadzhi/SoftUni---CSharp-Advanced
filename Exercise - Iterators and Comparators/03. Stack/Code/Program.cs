using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack {
    class Program {
        static void Main() {
            CustomStack<int> stack = new CustomStack<int>();
        
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END") {
                string[] commandParts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
               
                if (commandParts[0] == "Push") {
                    int[] numbers = Array.ConvertAll(commandParts[1..], int.Parse);
                    stack.Push(numbers);
                }
                else if (commandParts[0] == "Pop") {
                    stack.Pop();
                }
            }
        
            foreach (var item in stack) {
                Console.WriteLine(item);
            }
            foreach (var item in stack) {
                Console.WriteLine(item);
            }
        }
    }
}

