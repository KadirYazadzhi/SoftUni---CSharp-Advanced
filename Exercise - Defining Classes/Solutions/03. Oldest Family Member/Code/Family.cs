namespace  DefiningClasses {
    public class Family {
        public static List<Person> people = new List<Person>();

        public static void AddMember(Person member) {
            people.Add(member);
        }

        public static Person GetOldestMember() {
            return people.OrderByDescending(p => p.Age).Take(1).First();
        }

        public static void FamilyReader() {
            int n = int.Parse(Console.ReadLine());
 
            for (int i = 0; i < n; i++) {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(data[0], int.Parse(data[1]));
                AddMember(person);
            }
            
            Console.WriteLine($"{GetOldestMember().Name} {GetOldestMember().Age}");
        }
    }
}