using System;
using System.Linq;

namespace CarManufacturer {
    class Car {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Tire[] tires;
        private Engine engine;
        
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }
        public Tire[] Tires { get { return tires; } set { tires = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        
        public Car() {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this() {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model,
            year) {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) :
            this(make, model, year, fuelQuantity, fuelConsumption) {
            this.Engine = engine;
            this.Tires = tires;
        }
        
        public void Drive(double distance) {
            if (fuelQuantity - distance * fuelConsumption > 0) return;
            
            Console.WriteLine("Not enough fuel to perform this trip!");
        }

        public string WhoAmI() {
            return $"Make: {this.Make}\n" +
                   $"Model: {this.Model}\n" +
                   $"Year: {this.Year}\n" +
                   $"Fuel: {this.FuelQuantity:F2}";
        }
    }
}