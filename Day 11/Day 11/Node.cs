using System;
using MorteTools;

namespace Day_11
{
    internal class Node
    {
        char type;
        int id;
        public Node(char type)
        {
            this.type = type;
            this.id = -1;
        }
        public Node(int id)
        {
            this.type = default;
            this.id = id;
        }

        public override string ToString()
        {
            string ret = string.Empty;
            if(id  == -1) { ret = type.ToString(); }
            else { ret = id.ToString(); }
            return ret;
        }
    }
}
