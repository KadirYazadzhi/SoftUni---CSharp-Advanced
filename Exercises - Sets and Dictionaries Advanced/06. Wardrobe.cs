using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        ReadData(n);
        
        string[] searched = Console.ReadLine().Split().ToArray();
        
        PrintElements(searched);
    }

    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            string[] data = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            if (!wardrobe.ContainsKey(data[0])) wardrobe[data[0]] = new Dictionary<string, int>();

            string[] clothes = data[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int j = 0; j < clothes.Length; j++) {
                if (wardrobe[data[0]].ContainsKey(clothes[j])) wardrobe[data[0]][clothes[j]]++;
                else wardrobe[data[0]][clothes[j]] = 1;
            }
        }
    }

    private static void PrintElements(string[] searched) {
        foreach ((string color, Dictionary<string, int> clothes) in wardrobe) {
            Console.WriteLine($"{color} clothes:");
            foreach ((string item, int count) in clothes) {
                if (color == searched[0] && item == searched[1]) {
                    Console.WriteLine($"* {item} - {count} (found!)");
                    continue;
                }
                
                Console.WriteLine($"* {item} - {count}");
            }
        }
    }
}

