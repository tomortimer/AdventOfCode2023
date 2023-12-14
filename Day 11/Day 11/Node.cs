using System;
using MorteTools;

namespace Day_11
{
    internal class Node
    {
        List<Tuple<int, int>> transformations;
        char type;
        public Node(List<Tuple<int, int>> transformations, char type)
        {
            this.transformations = transformations;
            this.type = type;
        }
    }
}
