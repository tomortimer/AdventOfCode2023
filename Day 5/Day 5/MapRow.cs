using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    internal class MapRow
    {
        private long outputStart;
        private long inputStart;
        private long range;

        public MapRow(long output, long input, long rangeInp) 
        {
            outputStart = output;
            inputStart = input;
            range = rangeInp;
        }

        public bool IsInDomain(long input)
        {
            bool ret = false;
            // range is non inclusive at top end
            if(inputStart <= input && input < (inputStart + range)) { ret= true;}
            return ret;
        }

        public bool IsInRange(long input)
        {
            bool ret = false;
            if(outputStart <= input && input < (outputStart + range)) { ret = true; }
            return ret;
        }

        public long Transform(long input)
        {
            long ret = -1;
            long difference = input - inputStart;
            return outputStart + difference;
        }

        //added for part 2
        public long ReverseTransform(long input)
        {
            long inversed = input - outputStart + inputStart;
            return inversed;
        }
    }
}
