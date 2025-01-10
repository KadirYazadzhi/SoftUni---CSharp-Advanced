using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Queue<string> cars = new Queue<string>();
    
    static void Main() {
        int greenLightDuration = int.Parse(Console.ReadLine());
        int freeWindowDuration = int.Parse(Console.ReadLine());
        
        ReadCars(greenLightDuration, freeWindowDuration);
        
    }

    private static void ReadCars(int greenLightDuration, int freeWindowDuration) {
        int totalCarsParssed = 0;
        
        string line = null;
        while ((line = Console.ReadLine()) != "END") {
            if (line == "green") {
                int remainingTime = greenLightDuration;

                while (remainingTime > 0 && cars.Count > 0) {
                    string currentCar = cars.Dequeue();
                    remainingTime -= currentCar.Length;

                    if (remainingTime < 0) {
                        int remainingParts = -1 * remainingTime;

                        if (remainingParts > freeWindowDuration) {
                            remainingParts -= freeWindowDuration;
                            
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[currentCar.Length - remainingParts]}.");
                            return;
                        }
                    }
                    
                    totalCarsParssed++;
                }
                continue;
            } 
            
            cars.Enqueue(line);
        }
        
        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{totalCarsParssed} total cars passed the crossroads.");
    }
}

