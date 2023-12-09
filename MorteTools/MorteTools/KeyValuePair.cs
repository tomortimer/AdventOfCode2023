using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorteTools
{
    public class KeyValuePair<K,T>
    {
        public K key;
        public T value;
        public KeyValuePair(K key, T value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
