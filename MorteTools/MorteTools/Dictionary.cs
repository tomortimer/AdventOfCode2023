using System;
using System.Threading.Tasks;

namespace MorteTools
{
    public class Dictionary<K,T>
    {
        List<K> keys;
        List<T> values;
        public Dictionary() 
        {
            keys = new List<K>();
            values = new List<T>();
        }

        public T this[K key]
        {
            //uses private methods - for readability I think?
            get { return RetrieveAt(key); }
            set { SetAt(key, value); }
        }

        public void Add(K key, T value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public T RetrieveAt(K key)
        {
            T ret = default;
            int ptr = keys.GetIndex(key);
            ret = values[ptr];
            return ret;
        }

        public void SetAt(K key, T value)
        {
            int ptr = keys.GetIndex(key);
            values[ptr] = value;
        }
    }
}
