namespace GenericBox {
    public class Box<T> {
        public T Value { get; private set; }
        public Type Type { get; private set; }

        public Box(T value) {
            this.Value = value;
            this.Type = value.GetType();
        }
    
        public override string ToString() {
            return $"{Type}: {Value}";
        }
    }
}

