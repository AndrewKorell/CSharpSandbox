using System.Collections;

namespace YeildTest {

    class Program {
        
        static void Main(string[] args){

            #region all even numbers below 100

            //standard generator 
            var num_even_to_100 = 
                from i in Enumerable.Range(i,99)
                where i % 2 == 0
                select i;

            #endregion

        }

        public class FibonacciSequence: IEnumerable, IEnumerator
        {
            

            private  int current = 1;
            private int previous = 1;

            public IEnumerator GetEnumerator()
            {
                return this;
            }

            object IEnumerator.Current
            {
                get { return current; }
            }

            public bool MoveNext()
            {
                int old = current;
                current = current + previous;
                previous = old;
                return current <= 100;
            }

            public void Reset()
            {
                current = 1;
                previous = 1;
            }
        }
    }

    public static class YieldReturn 
    {
        public static IEnumerable<int> GetFibonacciSequence()
        {
            int current = 1, previous = 1;
            while(current <= 100)
            {
                yield return current;
                int old = current;
                current = current + previous;
                previous = old;
            }
        }
    }
}