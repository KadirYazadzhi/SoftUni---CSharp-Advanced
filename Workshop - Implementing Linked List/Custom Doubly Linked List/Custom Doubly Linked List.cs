using System;
using System.Linq;

namespace  DoubleLinkedList {
    class StartUp() {
        public static void Main(string[] args) {
            
        }
    }

    public class DoubleLinkedList {
        private class ListNode {
            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public ListNode(int value) {
                this.Value = value;
            }
        }
        private ListNode head;
        private ListNode tail;
        
        public int Count { get; private set; }

        public void AddFirst(int value) {
            this.Count++;
            
            if (this.Count == 0) {
                this.head = this.tail = new ListNode(value);
                return;
            }
            
            var newHead = new ListNode(value);
            newHead.NextNode = this.head;
            this.head.PreviousNode = newHead;
            this.head = newHead;
        }

        public void AddLast(int value) {
            this.Count++;
            
            if (this.Count == 0) {
                this.head = this.tail = new ListNode(value);
                return;
            }
            
            var newTail = new ListNode(value);
            newTail.PreviousNode = this.tail;
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }

        public int RemoveFirst() {
            if (this.Count == 0) throw new InvalidOperationException();
            
            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head == null) {
                this.tail = null;
            }
            else {
                this.head.PreviousNode = null;
            }
            
            this.Count--;
            
            return firstElement;
        }

        public int RemoveLast() {
            if (this.Count == 0) throw new InvalidOperationException();
            
            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail == null) {
                this.head = null;
            }
            else {
                this.tail.NextNode = null;
            }
            
            this.Count--;

            return lastElement;
        }

        public void ForEach(Action<int> action) {
            var currentNode = this.head;

            while (currentNode != null) {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray() {
            int[] array = new int[this.Count];
            int counter = 0;
            var currentNode = this.head;

            while (currentNode != null) {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }
            
            return array;
        }
    }
}

