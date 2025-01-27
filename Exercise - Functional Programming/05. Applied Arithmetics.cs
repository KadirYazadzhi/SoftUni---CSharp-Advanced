using System;

class Program {
    static void Main() {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        Func<List<int>, List<int>> add = nums => nums.Select(n => n + 1).ToList();
        Func<List<int>, List<int>> multiply = nums => nums.Select(n => n * 2).ToList();
        Func<List<int>, List<int>> subtract = nums => nums.Select(n => n - 1).ToList();
        Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));
        
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "end") {
            switch (command) {
                case "add": numbers = add(numbers);
                    break;
                case "multiply": numbers = multiply(numbers);
                    break;
                case "subtract": numbers = subtract(numbers);
                    break;
                case "print": print(numbers);
                    break;
            }
        }
    }
}
