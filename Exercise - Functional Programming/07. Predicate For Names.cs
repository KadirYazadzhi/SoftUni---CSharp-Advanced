using System;

class Program {
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        List<string> names = Console.ReadLine().Split().ToList();

        Predicate<string> isValidLength = name => name.Length <= n; 
       
        names.Where(name => isValidLength(name)).ToList().ForEach(Console.WriteLine);
    }
}
