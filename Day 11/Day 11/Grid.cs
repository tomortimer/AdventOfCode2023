using System;
using MorteTools;
namespace Day_11
{
    internal class Grid
    {
        Dictionary<int, Node> nodes = new Dictionary<int,Node>();
        int width;
        int height;
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            nodes = new Dictionary<int,Node>();
        }
        public void AddNode(char type, int x, int y)
        {
            int pos = x * y*width;
            List<Tuple<int,int>> transformations = new List<Tuple<int, int>>([new Tuple<int,int>(0, -1), new Tuple<int, int>(1, 0), new Tuple<int, int>(0, 1), new Tuple<int, int>(-1, 0)]);
            if(x == 0) { transformations.Remove(new Tuple<int, int>(-1, 0)); }
            if(y == 0) { transformations.Remove(new Tuple<int, int>(0, -1)); }
            if(x == width - 1) { transformations.Remove(new Tuple<int, int>(0, 1)); }
            if(y == height - 1) { transformations.Remove(new Tuple<int,int>(0,1)); }
            nodes.Add(pos, new Node(transformations, type));
        }
    }
}
