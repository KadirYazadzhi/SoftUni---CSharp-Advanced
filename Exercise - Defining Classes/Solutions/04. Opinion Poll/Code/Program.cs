using System;
using System.Linq;

namespace  DefiningClasses {
    public class StartUp {
        public static void Main() {
            PersonReader();
        }

        public static void PersonReader() {
            List<Person> people = new List<Person>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                var person = new Person(data[0], int.Parse(data[1]));
                people.Add(person);
            }

            foreach (Person person in people.OrderBy(person => person.Name).Where(person => person.Age > 30)) {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
