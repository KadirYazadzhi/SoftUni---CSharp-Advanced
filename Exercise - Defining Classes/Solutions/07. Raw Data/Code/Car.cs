namespace DefiningClasses {
    class Car {
        public string Model { get; }
        public Engine Engine { get; }
        public Cargo Cargo { get; }
        public List<Tire> Tires { get; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<Tire> tires) {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoWeight, cargoType);
            Tires = tires;
        }
    }
}
