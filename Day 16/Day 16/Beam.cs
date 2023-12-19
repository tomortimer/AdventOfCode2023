using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day_16
{
    internal class Beam
    {
        public Vector2 pos;
        public int direction;
        public Beam(Vector2 pos, int direction)
        {
            this.pos = pos;
            this.direction = direction;
        }
    }
}
