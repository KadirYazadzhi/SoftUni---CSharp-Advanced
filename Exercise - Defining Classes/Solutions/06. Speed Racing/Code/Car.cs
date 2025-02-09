namespace DefiningClasses {
    public class Car {
        public string Model { get; private set; }
        public double FuelAmount { get; private set; }
        public double FuelConsumptionPerKilometer { get; private set; }
        public double TravelledDistance { get; private set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public void CarMove(double distance) {
            if (distance * FuelConsumptionPerKilometer > FuelAmount) {
               Console.WriteLine("Insufficient fuel for the drive"); 
               return;
            }
            
            TravelledDistance += distance;
            FuelAmount -= distance * FuelConsumptionPerKilometer;
        }
    } 
}
