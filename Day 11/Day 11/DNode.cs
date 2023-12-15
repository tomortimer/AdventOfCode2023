using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    internal class DNode
    {
        public Tuple<int, int> coord;
        public int distance;
        public DNode(Tuple<int, int> coord, int distance)
        {
            this.coord = coord;
            this.distance = distance;
        }
    }
}
