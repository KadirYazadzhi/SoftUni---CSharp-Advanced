using System;
using System.Linq;
using System.Globalization;

namespace  DefiningClasses {
    public class StartUp {
        private static List<Car> cars = new List<Car>();

        public static void Main() {
            Drive();
        }

        public static void Drive() {
           ReadCars();
           DriveCars();
           PrintCars();
        }

        private static void DriveCars() {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End") {
                string[] commands = command.Split().ToArray();

                Car car = IsExist(commands[1]);

                car.CarMove(double.Parse(commands[2]));
            }
        }

        private static void ReadCars() {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                string[] data = Console.ReadLine().Split();

                if (data[0] == "Drive") { }

                if (IsExist(data[0]) != null) continue;

                Car car = new Car(data[0], double.Parse(data[1]), double.Parse(data[2]));
                cars.Add(car);
            }
        }

        private static void PrintCars() {
            foreach (Car car in cars) {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
                    
            }
        } 

        private static Car IsExist(string model) {
            foreach (Car car in cars) {
                if (car.Model == model) {
                    return car;
                }
            }
            
            return null;
        }
    }
}
