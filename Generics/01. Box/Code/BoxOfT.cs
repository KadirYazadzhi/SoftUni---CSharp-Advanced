using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxOfT {
    public class Box<T> {
        private List<T> boxes = new List<T>();

        public void Add(T box) {
            boxes.Add(box);
        }

        public T Remove() {
            T lastElement = boxes[^1];
            boxes.RemoveAt(boxes.Count - 1);
            return lastElement;
        }

        public int Count => boxes.Count;
    }
}
