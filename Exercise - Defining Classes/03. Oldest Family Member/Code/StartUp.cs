using System;
using System.Linq;

namespace  DefiningClasses {
    public class StartUp {
        public static void Main() {
            FamilyReader();
        }
        
        public static void FamilyReader() {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            for (int i = 0; i < n; i++) {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(data[0], int.Parse(data[1]));
                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
