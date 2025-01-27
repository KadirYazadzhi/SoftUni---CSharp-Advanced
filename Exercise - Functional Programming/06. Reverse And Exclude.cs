using System;

class Program {
    static void Main() {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
        int n = int.Parse(Console.ReadLine());
        
        Func<List<int>, List<int>> exclude = nums => nums.Where(num => num % n != 0).ToList();
        
        Console.WriteLine(string.Join(" ", exclude(numbers)));
    }
}
