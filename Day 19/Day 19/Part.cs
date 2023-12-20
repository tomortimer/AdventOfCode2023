using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Day_19
{
    internal class Part
    {
        public long x;
        public long m;
        public long a;
        public long s;
        public string workflow;

        public Part(string inp)
        {
            string[] values = inp.Split(new char[] { ',', '=' });
            x = long.Parse(values[1]);
            m = long.Parse(values[3]);
            a = long.Parse(values[5]);
            s = long.Parse(values[7]);
            workflow = "in";
        }

        public long GetScore()
        {
            return x + m + a + s;
        }
    }
}
