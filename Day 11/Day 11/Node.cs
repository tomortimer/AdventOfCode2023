using System;
using MorteTools;

namespace Day_11
{
    internal class Node
    {
        char type;
        public Node(char type)
        {
            this.type = type;
        }
        public override string ToString()
        {
            return type.ToString();
        }
    }
}
