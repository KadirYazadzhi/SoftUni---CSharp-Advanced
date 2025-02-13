using System;
using System.Collections;
using System.Collections.Generic;

namespace Person {
    class Program {
        static void Main() {
            List<Person> people = new List<Person>();
            
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END") {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                Person person = new Person(data[0], int.Parse(data[1]), data[2]);
                
                people.Add(person);
            }
            
            int position = int.Parse(Console.ReadLine());
            Person targetPerson = people[position - 1];

            int matches = 0;
            foreach (Person person in people) {
                if (Comparer<Person>.Default.Compare(targetPerson, person) == 0) {
                    matches++;
                }
            }
            
            if (matches == 1) Console.WriteLine("No matches");
            else Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
        }
    }
}

