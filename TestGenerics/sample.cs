
using System.ComponentModel;

namespace Generics
{

    //Advantages: 
    //using "object" has a performance hit against base types like int and string
    //Less code reuse

    class GenericList<T>
    {
        public void add(T value)
        {
            throw new NotImplementedException;
        }

        public T this[int index]
        {
            get { throw new NotImplementedException; }
        }
    }

    public class GenerticDictionary<TKey, TValue>
    {
        public void add(TKey  key, TValue value)
        {
            throw new NotImplementedException;
        }

        public TValue this[TKey key]
        {
            get { throw new NotImplementedException; }
        }
    }

}