namespace DefiningClasses {
    public class Engine {
        public string Model { get; }
        public int Power { get; }
        public int? Displacement { get; }
        public string Efficiency { get; }

        public Engine(string model, int power, int? displacement = null, string efficiency = null) {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public override string ToString() =>
            $"{Model}:\n    Power: {Power}\n    Displacement: {(Displacement.HasValue ? Displacement.ToString() : "n/a")}\n    Efficiency: {(string.IsNullOrEmpty(Efficiency) ? "n/a" : Efficiency)}";
    }
}
