using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        List<char> chars = Console.ReadLine().ToCharArray().ToList();
        Stack<char> line = new Stack<char>();

        foreach (char character in chars) {
            line.Push(character);
        }

        foreach (char character in line) {
            Console.Write(character);
        }
    }
}
