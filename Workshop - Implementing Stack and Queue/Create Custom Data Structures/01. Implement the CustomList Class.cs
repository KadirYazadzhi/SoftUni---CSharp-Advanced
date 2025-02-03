using System;
using System.Linq;

namespace CustomList {
    class StartUp {
        public static void Main(string[] args) {
            
        }
    }

    public class CustomList {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList() {
            this.items = new int[InitialCapacity];
        }
        
        public int Count { get; private set; }

        public int this[int index] {
            get {
                if (index >= this.Count || index < 0) throw new ArgumentOutOfRangeException();
                return this.items[index];
            }
            set {
                if (index >= this.Count || index < 0) throw new ArgumentOutOfRangeException();
                items[index] = value;
            }
        }

        private void Resize() {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++) {
                copy[i] = this.items[i];
            }
            
            this.items = copy;
        }

        public void Add(int item) {
            if (this.Count == this.items.Length) this.Resize();
            
            this.items[this.Count] = item;
            this.Count++;
        }

        private void Shift(int index) {
            for (int i = index; i < this.Count - 1; i++) {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink() {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++) {
                copy[i] = this.items[i];
            }
            
            this.items = copy;
        }

        public int RemoveAt(int index) {
            if (index >= this.Count || index < 0) throw new ArgumentOutOfRangeException();
            
            var item = this.items[index];
            this.Shift(index);
            this.Count--;

            if (this.Count <= this.items.Length / 4 && this.items.Length > InitialCapacity) {
                this.Shrink();
            }

            return item;
        }

        private void ShiftToRight(int index) {
            for (int i = Count; i > index; i--) {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Insert(int index, int element) {
            if (index > this.Count || index < 0) throw new IndexOutOfRangeException();
            
            if (this.Count == this.items.Length) this.Resize();
            
            this.ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element) {
            for (int i = 0; i < this.Count; i++) {
                if (this.items[i] == element) return true;
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex) {
            if (firstIndex < 0 || firstIndex >= this.Count || secondIndex < 0 || secondIndex >= this.Count) {
                throw new ArgumentOutOfRangeException();
            }
            
            (this.items[firstIndex], this.items[secondIndex]) = (this.items[secondIndex], this.items[firstIndex]);
        }

        public int[] ToArray() {
            int[] result = new int[this.Count];
            for (int i = 0; i < this.Count; i++) {
                result[i] = this.items[i];
            }
            return result;
        }
    }
}

