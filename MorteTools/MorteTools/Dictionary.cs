using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MorteTools
{
    public class Dictionary<K,T> : IEnumerable<KeyValuePair<K, T>>
    {
        List<K> keys;
        List<T> values;
        public Dictionary() 
        {
            keys = new List<K>();
            values = new List<T>();
        }
        
        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            List<KeyValuePair<K,T>> enumList = new List<KeyValuePair<K,T>>();
            foreach(K key in keys)
            {
                enumList.Add(new KeyValuePair<K, T>(key, this[key]));
            }
            return new Enumerator<KeyValuePair<K, T>>(enumList);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // this calls the IEnumerator<Foo> GetEnumerator method
            // as explicit method implementations aren't used for method resolution in C#
            // polymorphism (IEnumerator<T> implements IEnumerator)
            // ensures this is type-safe
            return GetEnumerator();
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
            if(ptr == -1) { ret = values[ptr]; }
            return ret;
        }

        public bool Contains(K key)
        {
            bool ret = false;
            if(keys.Contains(key)) { ret = true; }
            return ret;
        }

        public void SetAt(K key, T value)
        {
            int ptr = keys.GetIndex(key);
            values[ptr] = value;
        }
    }
}
