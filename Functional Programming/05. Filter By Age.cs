using System;
using System.Collections.Generic;
using System.Linq;

public class Student {
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program {
    static void Main() {
        int n = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>();
        for (int i = 0; i < n; i++) {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            students.Add(new Student { Name = input[0], Age = int.Parse(input[1]) });
        }

        string condition = Console.ReadLine();
        int ageThreshold = int.Parse(Console.ReadLine());
        string format = Console.ReadLine();

        Func<Student, bool> filter = CreateFilter(condition, ageThreshold);
        List<Student> filteredStudents = students.Where(filter).ToList();

        Action<Student> printer = CreatePrinter(format);
        PrintFilteredStudents(filteredStudents, printer);
    }

    static Func<Student, bool> CreateFilter(string condition, int ageThreshold) {
        if (condition == "older")
            return s => s.Age >= ageThreshold;
        else if (condition == "younger")
            return s => s.Age < ageThreshold;
        else
            throw new ArgumentException("Invalid condition");
    }

    static Action<Student> CreatePrinter(string format) {
        if (format == "name")
            return s => Console.WriteLine(s.Name);
        else if (format == "age")
            return s => Console.WriteLine(s.Age);
        else if (format == "name age")
            return s => Console.WriteLine($"{s.Name} - {s.Age}");
        else
            throw new ArgumentException("Invalid format");
    }

    static void PrintFilteredStudents(List<Student> students, Action<Student> printer) {
        foreach (var student in students) {
            printer(student);
        }
    }
}
