using System;
using System.Linq;

class Program {
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        Predicate<int> IsDivisibleByAll = num => numbers.All(div => num % div == 0);

        List<int> result = Enumerable.Range(1, n).Where(num => IsDivisibleByAll(num)).ToList();
        
        Console.WriteLine(string.Join(" ", result));
    }
}
