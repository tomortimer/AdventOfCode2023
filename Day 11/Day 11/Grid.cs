using System;
using MorteTools;
namespace Day_11
{
    internal class Grid
    {
        Dictionary<int, Node> nodes;
        Dictionary<int, int> hashtagNodes;
        int width;
        int height;
        int hashtagNodeCtr;
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            nodes = new Dictionary<int,Node>();
            hashtagNodes = new Dictionary<int, int>();
            hashtagNodeCtr = 0;
        }
        public void AddNode(char type, int x, int y)
        {
            int pos = x + y*width;
            List<Tuple<int,int>> transformations = new List<Tuple<int, int>>([new Tuple<int,int>(0, -1), new Tuple<int, int>(1, 0), new Tuple<int, int>(0, 1), new Tuple<int, int>(-1, 0)]);
            //if(x == 0) { transformations.Remove(new Tuple<int, int>(-1, 0)); }
            //if(y == 0) { transformations.Remove(new Tuple<int, int>(0, -1)); }
            //if(x == width - 1) { transformations.Remove(new Tuple<int, int>(0, 1)); }
            //if(y == height - 1) { transformations.Remove(new Tuple<int,int>(0,1)); }
            nodes.Add(pos, new Node(type));
            if(type == '#') 
            {
                hashtagNodes.Add(hashtagNodeCtr, pos);
                hashtagNodeCtr++;
            }
        }
        public int DistanceBetween(int nodeOne, int nodeTwo)
        {
            Tuple<int,int> nodeOneCoord = ConvertIndexToCoord(hashtagNodes[nodeOne]);
            Tuple<int,int> nodeTwoCoord = ConvertIndexToCoord(hashtagNodes[nodeTwo]);
            int distance = (int)Math.Sqrt(Math.Pow(nodeTwoCoord.Item1 - nodeOneCoord.Item1, 2) + Math.Pow(nodeTwoCoord.Item2 - nodeOneCoord.Item1, 2));
            return distance;
        }
        public Tuple<int,int> ConvertIndexToCoord(int index)
        {
            int y = index / width;
            int x = index % width;
            return new Tuple<int, int>(x, y);
        }
        public void InsertColumn(int index, char symbol)
        {
            for(int y = 0; y < height; y++)
            {
                for(int x = Width - 1; x >= index; x--)
                {
                    Node tmp = nodes[x +y*width];
                    nodes[x + 1 + y * width] = tmp;
                }
                nodes[index + y * width] = new Node(symbol);

            }

            width++;
        }
        public int Height { get { return height; } set { height = value; } }
        public int Width { get { return width; } set { width = value; } }
        public void PrintGrid()
        {
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Console.Write(nodes[x + y*width].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
