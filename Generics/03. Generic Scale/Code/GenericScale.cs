using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericScale {
    public class EqualityScale<T> {
        public T Left { get; private set; }
        public T Right { get; private set; }
        
        public EqualityScale(T left, T right) {
            Left = left;
            Right = right;
        }

        public bool AreEqual() {
            return Left.Equals(Right);
        }
    }
}

