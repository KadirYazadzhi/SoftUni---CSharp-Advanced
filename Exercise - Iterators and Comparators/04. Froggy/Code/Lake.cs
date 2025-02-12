using System.Collections;

namespace Froggy {
    public class Lake : IEnumerable<int> {
        private readonly int[] stones;

        public Lake(IEnumerable<int> stones) {
            this.stones = stones.ToArray();
        }

        public IEnumerator<int> GetEnumerator() {
            for (int i = 0; i < this.stones.Length; i += 2) {
                yield return this.stones[i];
            }

            for (int i = this.stones.Length - this.stones.Length % 2 - 1; i >= 0; i -= 2) {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}