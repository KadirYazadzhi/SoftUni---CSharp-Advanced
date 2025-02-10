using System;
using System.Collections.Generic;

namespace SoftUniParking {
    public class Parking {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity) {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count {
            get { return this.cars.Count; }
        }

        public string AddCar(Car car) {
            if (this.cars.Exists(c => c.RegistrationNumber == car.RegistrationNumber)) {
                return "Car with that registration number, already exists!";
            }

            if (this.cars.Count >= this.capacity) {
                return "Parking is full!";
            }

            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber) {
            Car car = this.cars.Find(c => c.RegistrationNumber == registrationNumber);

            if (car == null) {
                return "Car with that registration number, doesn't exist!";
            }

            this.cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber) {
            return this.cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers) {
            foreach (string registrationNumber in registrationNumbers) {
                Car car = this.cars.Find(c => c.RegistrationNumber == registrationNumber);
                if (car != null) {
                    this.cars.Remove(car);
                }
            }
        }
    }

}