namespace DefiningClasses {
    public class Trainer {
        public string Name { get; set; }
        public int Badges { get; set; } = 0; 
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public Trainer(string name) {
            Name = name;
        }

        public void AddPokemon(Pokemon pokemon) {
            Pokemons.Add(pokemon);
        }
    }
}