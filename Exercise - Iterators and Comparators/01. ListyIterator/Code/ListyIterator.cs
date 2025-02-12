namespace ListyIterator;

public class ListyIterator<T> {
    private readonly List<T> list;
    private int index;

    public ListyIterator(IEnumerable<T> values) {
        this.list = new List<T>(values);
    }

    public T Current => this.GetCurrentElement();

    public bool Move() {
        if (!this.HasNext()) return false;
        
        this.index++;
        return true;
    }

    public bool HasNext() => this.index + 1 < this.list.Count;

    private T GetCurrentElement() {
        if (this.index >= this.list.Count) throw new InvalidOperationException("Invalid Operation!");
        
        return this.list[this.index];
    }
}