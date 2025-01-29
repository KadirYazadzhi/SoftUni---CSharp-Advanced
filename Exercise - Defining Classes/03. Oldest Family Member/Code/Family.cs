namespace  DefiningClasses {
    public class Family() {
        public List<Person> people = new List<Person>();

        public void AddMember(Person member) {
            people.Add(member);
        }

        public Person GetOldestMember() {
            return people.OrderByDescending(p => p.Age).Take(1).First();
        }
    }
}
