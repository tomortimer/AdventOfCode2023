using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day_19
{
    internal class Workflow
    {
        List<Func<Part, bool>> comparisons;
        public List<string> funcs; // want to store string for pt2
        public List<string> outFuncs;
        public List<int> accepterFunctions;
        string defaultOut;

        public Workflow(string inp)
        {
            comparisons = new List<Func<Part, bool>>();
            outFuncs = new List<string>();
            accepterFunctions = new List<int>();
            funcs = new List<string>();

            string[] parts = inp.Split(',');
            for(int i = 0; i < parts.Length - 1; i++)
            {
                string part = parts[i];

                //parse parts
                string comparison = part.Split(':')[0];
                //placeholder
                Func<Part, bool> tmp = x => x.a == 0;

                //parse function
                if (comparison.Contains('>'))
                {
                    string asset = comparison.Split('>')[0];
                    long compVal = long.Parse(comparison.Split('>')[1]);
                    switch (asset)
                    {
                        case "x": tmp = x => x.x > compVal; break;
                        case "m": tmp = x => x.m > compVal; break;
                        case "a": tmp = x => x.a > compVal; break;
                        case "s": tmp = x => x.s > compVal; break;
                    }
                    
                }
                else
                {
                    string asset = comparison.Split('<')[0];
                    long compVal = long.Parse(comparison.Split('<')[1]);
                    switch (asset)
                    {
                        case "x": tmp = x => x.x < compVal; break;
                        case "m": tmp = x => x.m < compVal; break;
                        case "a": tmp = x => x.a < compVal; break;
                        case "s": tmp = x => x.s < compVal; break;
                    }
                }
                //parse output
                string outFunc = part.Split(":")[1];

                comparisons.Add(tmp);
                outFuncs.Add(outFunc);
                if(outFunc == "A")
                {
                    accepterFunctions.Add(outFuncs.Count - 1);
                }
                funcs.Add(comparison);
            }
            defaultOut = parts[parts.Length - 1];
            if(defaultOut == "A") { accepterFunctions.Add(outFuncs.Count - 1); }
        }

        public string GetNextState(Part p)
        {
            string ret = defaultOut;
            for(int i = 0; i < outFuncs.Count; i++)
            {
                if (comparisons[i](p)) { ret = outFuncs[i]; i = outFuncs.Count; }
            }
            return ret;
        }

    }
}
