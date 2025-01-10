using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Queue<int> locks = new Queue<int>();
    private static Stack<int> bullets = new Stack<int>();
    
    static void Main() { 
        int bulletPrice = int.Parse(Console.ReadLine());
        int gunBarrelSize = int.Parse(Console.ReadLine());
        bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        int value = int.Parse(Console.ReadLine());
        
        Shoot(bulletPrice, gunBarrelSize, value);
    }

    private static void Shoot(int bulletPrice, int gunBarrelSize, int value) {
        int bulletsInBarrel = gunBarrelSize;
        
        while (locks.Count > 0 && bullets.Count > 0) {
            if (bullets.Pop() <= locks.Peek()) {
                locks.Dequeue();
                Console.WriteLine("Bang!");
            }
            else {
                Console.WriteLine("Ping!");
            }
            
            bulletsInBarrel--;
            value -= bulletPrice;

            if (bulletsInBarrel == 0 && bullets.Count > 0) {
                Console.WriteLine("Reloading!");
                bulletsInBarrel = gunBarrelSize;
            }
        }

        if (bullets.Count == 0 && locks.Count > 0) {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            return;
        }
        
        Console.WriteLine($"{bullets.Count} bullets left. Earned ${value}");
    }
}
