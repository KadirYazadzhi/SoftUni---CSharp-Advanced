namespace  DefiningClasses {
    public class Person {
        private string name;
        private int age;
        
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person() {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this() {
            Age = age;
        }

        public Person(string name, int age) : this() {
            Name = name;
            Age = age;
        }
    }
}
