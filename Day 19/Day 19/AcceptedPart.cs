using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_19
{
    internal class AcceptedPart
    {
        long lowerX;
        long upperX;
        long lowerM;
        long upperM;
        long lowerA;
        long upperA;
        long lowerS;
        long upperS;

        Tuple<string, int> currentWorkflowAndPos;

        public AcceptedPart(long lowerX, long upperX, long lowerM, long upperM, long lowerA, long upperA, long lowerS, long upperS, Tuple<string,int> startPos)
        {
            this.lowerA = lowerA;
            this.upperA = upperA;
            this.lowerX = lowerX;
            this.upperX = upperX;
            this.lowerM = lowerM;
            this.upperM = upperM;
            this.lowerS = lowerS;
            this.upperS = upperS;
            this.currentWorkflowAndPos = startPos;
        }

        public long GetScore()
        {
            return (upperX - lowerX) * (upperM - lowerM) * (upperA - lowerA) * (upperS - lowerS);
        }
    }
}
