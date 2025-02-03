using System;
using System.Linq;

namespace CustomQueue {
    class StartUp {
        public static void Main(string[] args) {
            
        }
    }

    public class CustomQueue {
       private const int InitialCapacity = 4;
       private const int FirstElementIndex = 0;
       private int[] items;
       private int count;

       public CustomQueue() {
           count = 0;
           items = new int[InitialCapacity];
       }
       
       public int Count => count;

       public void Enqueue(int item) {
           if (items.Length == count) IncreaseSize();
           items[count] = item;
           count++;
       }

       private void IncreaseSize() {
           int[] tempArr = new int[items.Length * 2];
           items.CopyTo(tempArr, 0);
           items = tempArr;
       }

       public int Dequeue() {
           EnsureNotEmpty();
           int firstElement = items[FirstElementIndex];
           ShiftLeft();
           count--;
           return firstElement;
       }

       private void EnsureNotEmpty() {
           if (count == 0) throw new InvalidOperationException("Queue is empty.");
       }

       private void ShiftLeft() {
           for (int i = 1; i < count; i++) {
               items[i - 1] = items[i];
           }
           items[count - 1] = default;
       }

       public int Peek() {
           EnsureNotEmpty();
           return items[FirstElementIndex];
       }

       public bool IsEmpty() {
           return count == 0;
       }

       public void Clear() {
           items = new int[InitialCapacity];
           count = 0;
       }

       public void ForEach(Action<int> action) {
           for (int i = 0; i < count; i++) {
               action(items[i]);
           }
       }
    }
}

