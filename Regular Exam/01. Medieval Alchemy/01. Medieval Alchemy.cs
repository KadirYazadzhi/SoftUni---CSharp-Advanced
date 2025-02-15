using System;
using System.Collections.Generic;
using System.Linq;

namespace Potions {
    public class StartUp {
        private static Queue<int> crystals;
        private static Stack<int> substances;
        private static List<Potion> potions = new List<Potion> {
            new Potion("Brew of Immortality", 110),
            new Potion("Essence of Resilience", 100),
            new Potion("Draught of Wisdom", 90),
            new Potion("Potion of Agility", 80),
            new Potion("Elixir of Strength", 70),
        };

        private static List<string> craftedPotions = new List<string>(); 

        public static void Main() {
            ReadData();
            StartLogic();
            PrintResults();
        }

        private static void ReadData() {
            substances = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            crystals = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
        }

        private static void StartLogic() {
            while (substances.Count > 0 && crystals.Count > 0 && potions.Any(p => !p.Availability)) {
                int sum = substances.Pop() + crystals.Dequeue();
                
                crystals.Enqueue(0);

                Potion bestMatch = potions.Where(p => !p.Availability && p.Points == sum).OrderByDescending(p => p.Points).FirstOrDefault();

                if (bestMatch != null) {
                    bestMatch.Availability = true;
                    craftedPotions.Add(bestMatch.Name); 
                    
                    if (potions.All(p => p.Availability)) break; 
                }
                else {
                    bestMatch = potions.Where(p => !p.Availability && p.Points < sum).OrderByDescending(p => p.Points).FirstOrDefault();

                    if (bestMatch != null) {
                        bestMatch.Availability = true;
                        craftedPotions.Add(bestMatch.Name); 
                        
                        if (potions.All(p => p.Availability)) break;
                        
                        if (substances.Count > 0) {
                            int nextSubstance = substances.Pop() * 2;
                            substances.Push(nextSubstance);
                        }
                    }
                }
                
                crystals = new Queue<int>(crystals.Select(x => x + 5).Where(c => c > 0));
            }
        }

        private static void PrintResults() {
            bool complete = potions.All(p => p.Availability);

            Console.WriteLine(complete ? "Success! The alchemist has forged all potions!" : "The alchemist failed to complete his quest.");

            if (craftedPotions.Count > 0) Console.WriteLine($"Crafted potions: {string.Join(", ", craftedPotions)}");
            
            if (substances.Count > 0) Console.WriteLine($"Substances: {string.Join(", ", substances)}");

            if (crystals.Count > 0) {
                if (complete) Console.WriteLine($"Crystals: {string.Join(", ", crystals)}");
                else Console.WriteLine($"Crystals: {string.Join(", ", crystals.Select(x => x -5))}");
            }
        }
    }

    public class Potion {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool Availability { get; set; }

        public Potion(string name, int points) {
            Name = name;
            Points = points;
            Availability = false;
        }

        public override string ToString() {
            return Name;
        }
    }
}
