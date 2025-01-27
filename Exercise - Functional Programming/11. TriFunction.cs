using System;
using System.Linq;

class Program {
    static void Main() {
        int targetSum = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split();

        Func<string, int, bool> isSumGreaterOrEqual = (name, sum) => name.Sum(c => c) >= sum;
        Func<string[], int, Func<string, int, bool>, string> findName = (collection, sum, criteria) =>
            collection.FirstOrDefault(name => criteria(name, sum));

        string result = findName(names, targetSum, isSumGreaterOrEqual);
        Console.WriteLine(result);
    }
}
