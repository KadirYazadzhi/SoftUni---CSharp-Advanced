namespace DefiningClasses {
    public class Car {
        public string Model { get; }
        public Engine Engine { get; }
        public int? Weight { get; }
        public string Color { get; }

        public Car(string model, Engine engine, int? weight = null, string color = null) {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public override string ToString() =>
            $"{Model}:\n  {Engine}\n  Weight: {(Weight.HasValue ? Weight.ToString() : "n/a")}\n  Color: {(string.IsNullOrEmpty(Color) ? "n/a" : Color)}";
    }
}
