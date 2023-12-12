using System;
using System.Net.Http.Headers;

namespace Day_10
{
    internal class Pipe
    {
        char type;
        public Pipe(char inp) 
        {
            type = inp;
        }

        public override string ToString()
        {
            return Convert.ToString(type);
        }

        public Tuple<Tuple<int,int>,Tuple<int,int>> Traverse(Tuple<int, int> inp)
        {
            Tuple<int, int> transformOne = Tuple.Create(0,0);
            Tuple<int, int> transformTwo = Tuple.Create(0,0);
            switch (type)
            {
                case '|':
                    transformOne = Tuple.Create(inp.Item1,inp.Item2 + 1);
                    transformTwo = Tuple.Create(inp.Item1, inp.Item2 - 1);
                    break;
                case 'L':
                    transformOne = Tuple.Create(inp.Item1, inp.Item2 - 1);
                    transformTwo = Tuple.Create(inp.Item1 + 1, inp.Item2);
                    break;
                case 'J':
                    transformOne = Tuple.Create(inp.Item1, inp.Item2 - 1);
                    transformTwo = Tuple.Create(inp.Item1 - 1, inp.Item2);
                    break;
                case '-':
                    transformOne = Tuple.Create(inp.Item1 + 1, inp.Item2);
                    transformTwo = Tuple.Create(inp.Item1 - 1, inp.Item2);
                    break;
                case 'F':
                    transformOne = Tuple.Create(inp.Item1 + 1, inp.Item2);
                    transformTwo = Tuple.Create(inp.Item1, inp.Item2 + 1);
                    break;
                case '7':
                    transformOne = Tuple.Create(inp.Item1 - 1, inp.Item2);
                    transformTwo = Tuple.Create(inp.Item1, inp.Item2 + 1);
                    break;
            }
            return Tuple.Create(transformOne, transformTwo);
        }

        public bool ConnectsNorth()
        {
            bool ret = false;
            if(type == '|' || type == 'L' || type == 'J') { ret = true; }
            return ret;
        }
        public bool ConnectsEast()
        {
            bool ret = false;
            if(type == '-' || type == 'L' || type == 'F') { ret = true; }
            return ret;
        }
        public bool ConnectsSouth()
        {
            bool ret = false;
            if(type == '|' || type == '7' || type == 'F') { ret = true; }
            return ret;
        }
        public bool ConnectsWest()
        {
            bool ret = false;
            if (type == '-' || type == '7' || type == 'J') { ret = true; }
            return ret;
        }
    }
}
