using System;
using System.Threading.Tasks;

namespace MorteTools
{
    internal class KeyValuePair<K, T>
    {
        public K Key;
        public T Value;
        public KeyValuePair(K key, T value)
        {
            Key = key;
            Value = value;
        }
        public T GetValue() { return Value; }
        public void SetValue(T value) { Value = value; }
        public bool Equals(KeyValuePair<K,T> pair)
        {
            if (Key.Equals(pair.Key)) { return true; }
            else {  return false; }
        }
    }
}
