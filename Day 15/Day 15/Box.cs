using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    internal class Box
    {
        List<int> focalLengths;
        List<string> lenses;

        public Box()
        {
            focalLengths = new List<int>();
            lenses = new List<string>();
        }

        public void RemoveFront(string inp)
        {
            if(lenses.Contains(inp))
            {
                int tmp = lenses.IndexOf(inp);
                lenses.RemoveAt(tmp);
                focalLengths.RemoveAt(tmp);
            }
            
        }

        public void AddLens(string inp)
        {
            if (lenses.Count() < 9)
            {


                string[] parts = inp.Split('=');
                string lens = parts[0];
                int focalDistance = int.Parse(parts[1]);
                if (lenses.Contains(lens))
                {
                    int tmp = lenses.IndexOf(lens);
                    focalLengths[tmp] = focalDistance;
                }
                else
                {
                    focalLengths.Add(focalDistance);
                    lenses.Add(lens);
                }
            }
        }

        public override string ToString()
        {
            string ret = "";
            for(int i = 0; i < lenses.Count; i++)
            {
                ret+= lenses[i] + " " + focalLengths[i];
            }
            return ret;
        }

        public int GetBoxPower()
        {
            int score = 0;
            for(int i = 0; i < focalLengths.Count(); i++) 
            {
                int val = (i+1) * focalLengths[i];
                score += val;
            }
            return score;
        }
    }
}
