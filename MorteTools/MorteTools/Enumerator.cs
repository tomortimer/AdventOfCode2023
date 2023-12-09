using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorteTools
{
    public class Enumerator<T> : IEnumerator<T>
    {
        private List<T> _items;
        private int _index;

        public Enumerator(List<T> items)
        {

            _items = items;
            _index = -1;
        }

        public void Reset() { _index = -1; }
        public bool MoveNext()
        {
            //quit enum when end of list reached
            _index++;
            if (_index >= _items.Count())
            {
                return false;
            }
            else { return true; }
        }
        public T Current
        {
            get
            {
                if (_index >= _items.Count()) { throw new InvalidEnumArgumentException(); }
                return _items[_index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (_index >= _items.Count()) { throw new InvalidEnumArgumentException(); }
                return _items[_index];
            }
        }

        public void Dispose()
        {
            _index = -1;
        }
    }
}