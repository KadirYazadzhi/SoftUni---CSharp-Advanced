using System;
using System.Collections.Generic;
using System.Linq;

namespace  DefiningClasses {
    public class StartUp {
        private static List<Car> cars = new List<Car>();
        
        static void Main() {
           ReadCarInfo();
           PrintCarType();
        }

        private static void ReadCarInfo() {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++) {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                List<Tire> tires = new List<Tire>();
                for (int j = 5; j < carInfo.Length; j += 2) {
                    double tirePressure = double.Parse(carInfo[j]);
                    int tireAge = int.Parse(carInfo[j + 1]);
                    tires.Add(new Tire(tirePressure, tireAge));
                }

                cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires));
            }
        }

        private static void PrintCarType() {
            string command = Console.ReadLine();
            if (command == "fragile") {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))) {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable") {
                foreach (var car in cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)) {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
