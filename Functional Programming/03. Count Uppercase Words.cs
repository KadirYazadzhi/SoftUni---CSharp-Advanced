using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program {
    private static Predicate<string> filter = IsCapital;
    
    static void Main() {
        string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(x => filter(x)).ToArray();
        
        Console.WriteLine(string.Join("\n", words));
    }

    private static bool IsCapital(string word) {
        return Char.IsUpper(word[0]);
    }
}
