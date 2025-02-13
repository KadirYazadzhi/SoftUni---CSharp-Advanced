namespace Person;

public class Person : IComparable<Person> {
    private readonly string Name;
    private readonly int Age;
    private readonly string Town;

    public Person(string name, int age, string town) {
        Name = name;
        Age = age;
        Town = town;
    }

    public int CompareTo(Person? other) {
        ArgumentNullException.ThrowIfNull(other);

        int nameComparison = Comparer<string>.Default.Compare(this.Name, other.Name);
        if (nameComparison != 0) return nameComparison;

        int ageComparison = Comparer<int>.Default.Compare(this.Age, other.Age);
        if (Age != 0) return ageComparison;

        int townComparison = Comparer<string>.Default.Compare(this.Town, other.Town);
        return townComparison;
    }
}