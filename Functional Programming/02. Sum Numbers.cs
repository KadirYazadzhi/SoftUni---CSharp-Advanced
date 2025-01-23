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
    static void Main() { 
        int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        Console.WriteLine(numbers.Length);
        Console.WriteLine(numbers.Sum());
    }
}

