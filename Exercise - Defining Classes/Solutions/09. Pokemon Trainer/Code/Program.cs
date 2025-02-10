using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses {
    class StartUp {
        private static List<Trainer> trainers = new List<Trainer>();
        
        static void Main(string[] args) {
            ReadTrainers();
            ReadElements();
            PrintTrainers();
        }

        private static void ReadTrainers() {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Tournament") {
                string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                if (!trainers.Any(t => t.Name == tokens[0])) trainers.Add(new Trainer(tokens[0]));
                
                
                var trainer = trainers.First(t => t.Name == tokens[0]);
                trainer.Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
            }
        }

        private static void ReadElements() {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End") {
                foreach (Trainer trainer in trainers) {
                    if (trainer.Pokemons.Any(p => p.Element == command)) {
                        trainer.Badges++;
                        continue;
                    }
             
                    foreach (Pokemon pokemon in trainer.Pokemons) {
                        pokemon.Health -= 10;
                    }
                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }
        }

        private static void PrintTrainers() {
            foreach (Trainer trainer in trainers.OrderByDescending(t => t.Badges)) {
                Console.WriteLine("{0} {1} {2}", trainer.Name, trainer.Badges, trainer.Pokemons.Count);
            }
        }
    }
}
