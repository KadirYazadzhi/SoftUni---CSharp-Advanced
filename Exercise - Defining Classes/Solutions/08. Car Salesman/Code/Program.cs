using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses {
        public class StartUp {
        static void Main() {
            int N = int.Parse(Console.ReadLine());
            var engines = ReadEngines(N);

            int M = int.Parse(Console.ReadLine());
            var cars = ReadCars(M, engines);

            foreach (var car in cars) {
                Console.WriteLine(car);
            }
        }

        static Dictionary<string, Engine> ReadEngines(int N) {
            var engines = new Dictionary<string, Engine>();
            for (int i = 0; i < N; i++) {
                var engineData = Console.ReadLine().Split();
                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                int? displacement = null;
                string efficiency = null;

                if (engineData.Length > 2) {
                    if (int.TryParse(engineData[2], out int d)) {
                        displacement = d;
                    } else {
                        efficiency = engineData[2];
                    }
                }
                if (engineData.Length > 3) {
                    efficiency = engineData[3];
                }
                
                engines[model] = new Engine(model, power, displacement, efficiency);
            }
            return engines;
        }

        static List<Car> ReadCars(int M, Dictionary<string, Engine> engines) {
            var cars = new List<Car>();
            for (int i = 0; i < M; i++) {
                var carData = Console.ReadLine().Split();
                string model = carData[0];
                string engineModel = carData[1];
                int? weight = null;
                string color = null;

                if (carData.Length > 2) {
                    if (int.TryParse(carData[2], out int w)) {
                        weight = w;
                    } else {
                        color = carData[2];
                    }
                }
                if (carData.Length > 3) {
                    color = carData[3];
                }
                
                cars.Add(new Car(model, engines[engineModel], weight, color));
            }
            return cars;
        }
    }
}