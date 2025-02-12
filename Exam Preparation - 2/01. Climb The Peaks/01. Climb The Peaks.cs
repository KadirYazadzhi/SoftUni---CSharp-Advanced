using System;
using System.Collections.Generic;
using System.Linq;

public class Program {
    private static Stack<int> quantity = new Stack<int>();
    private static Queue<int> stamina = new Queue<int>();
    private static List<(string name, int difficulty)> mountains = new List<(string, int)> {
        ("Vihren", 80),
        ("Kutelo", 90),
        ("Banski Suhodol", 100),
        ("Polezhan", 60),
        ("Kamenitza", 70)
    };
    private static List<string> conqueredPeaks = new List<string>();

    public static void Main() {
        ReadData();
        StartLogic();
    }

    private static void ReadData() {
        quantity = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
        stamina = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
    }

    private static void StartLogic() {
        int index = 0;
        
        while (quantity.Count > 0 && stamina.Count > 0 && index < mountains.Count) {
            int food = quantity.Pop();
            int energy = stamina.Dequeue();
            
            if (food + energy >= mountains[index].difficulty) {
                conqueredPeaks.Add(mountains[index].name);
                index++;
            }
        }

        if (conqueredPeaks.Count == mountains.Count) {
            Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
        } 
        else {
            Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
        }

        if (conqueredPeaks.Count > 0) {
            Console.WriteLine("Conquered peaks:");
            Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
        }
    }
}
