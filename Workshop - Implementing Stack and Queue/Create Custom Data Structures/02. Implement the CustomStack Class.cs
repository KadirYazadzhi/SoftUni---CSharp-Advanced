using System;
using System.Linq;

namespace CustomStack {
    class StartUp {
        public static void Main(string[] args) {

        }
    }

    public class CustomStack {
        private const int InitialCapacity = 4;
        private int[] items;
        private int count;

        public CustomStack() {
            this.count = 0;
            this.items = new int[InitialCapacity];
        }

        public int Count { get { return this.count; } }

        public void Push(int element) {
            if (this.items.Length == this.count) {
                var nextItems = new int[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++) {
                    nextItems[i] = this.items[i];
                }
                this.items = nextItems;
            }
            this.items[this.count] = element;
            count++;
        }

        public int Pop() {
            if (this.count == 0) throw new InvalidOperationException("Stack is empty.");
            var lastIndex = this.count - 1;
            int last = this.items[lastIndex];
            this.items[lastIndex] = default(int);
            this.count--;
            return last;
        }

        public int Peek() {
            if (this.count == 0) throw new InvalidOperationException("Stack is empty.");
            return this.items[this.count - 1];
        }

        public bool IsEmpty() {
            return this.count == 0;
        }

        public void ForEach(Action<int> action) {
            for (int i = 0; i < this.count; i++) {
                action(this.items[i]);
            }
        }
    }
}

