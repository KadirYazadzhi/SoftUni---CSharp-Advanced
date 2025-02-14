using System;
using System.Linq;

class RushHour {
    private static Queue<int> times = new Queue<int>();
    private static Stack<int> tasks = new Stack<int>();
    private static Dictionary<string, int> ducks = new Dictionary<string, int>() {
        { "Darth Vader Ducky", 0 },
        { "Thor Ducky", 0 },
        { "Big Blue Rubber Ducky", 0 },
        { "Small Yellow Rubber Ducky", 0 }
    };
    
    public static void Main() {
        ReadData();
        StartLogic();
        PrintData();
    }

    private static void ReadData() {
        times = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        tasks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
    }

    private static void StartLogic() {
        while (times.Any() && tasks.Any()) {
            int sum = times.Peek() * tasks.Peek();

            if ((sum >= 0) && (sum <= 240)) {
                if ((sum >= 0) && (sum <= 60)) {
                    ducks["Darth Vader Ducky"]++;
                }
                else if ((sum >= 61)&&(sum <= 120)) {
                    ducks["Thor Ducky"]++;
                }
                else if ((sum >= 121) && (sum <= 180)) {
                    ducks["Big Blue Rubber Ducky"]++;
                }
                else if ((sum >= 181) && (sum <= 240)) {
                    ducks["Small Yellow Rubber Ducky"]++;
                }
        
                times.Dequeue();
                tasks.Pop();
                continue;
            }

            tasks.Push(tasks.Pop() - 2);
            times.Enqueue(times.Dequeue());

        }
    }

    private static void PrintData() {
        Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
        
        foreach (var duck in ducks) {
            Console.WriteLine($"{duck.Key}: {duck.Value}");
        }
    }
}
