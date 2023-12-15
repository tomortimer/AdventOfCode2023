using System;
using MorteTools;
namespace Day_11
{
    internal class Grid
    {
        private Node[,] nodes;
        Dictionary<int, Tuple<int,int>> hashtagNodes;
        int width;
        int height;
        int hashtagNodeCtr;
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            nodes = new Node[width, height];
            hashtagNodes = new Dictionary<int, Tuple<int,int>>();
            hashtagNodeCtr = 0;
        }

        public void AddNode(char type, int x, int y)
        {
            List<Tuple<int,int>> transformations = new List<Tuple<int, int>>([new Tuple<int,int>(0, -1), new Tuple<int, int>(1, 0), new Tuple<int, int>(0, 1), new Tuple<int, int>(-1, 0)]);
            //if(x == 0) { transformations.Remove(new Tuple<int, int>(-1, 0)); }
            //if(y == 0) { transformations.Remove(new Tuple<int, int>(0, -1)); }
            //if(x == width - 1) { transformations.Remove(new Tuple<int, int>(0, 1)); }
            //if(y == height - 1) { transformations.Remove(new Tuple<int,int>(0,1)); }
            nodes[x,y] = new Node(type);
            if(type == '#') 
            {
                hashtagNodes.Add(hashtagNodeCtr, new Tuple<int,int>(x,y));
                nodes[x, y] = new Node(Convert.ToChar(hashtagNodeCtr.ToString()));
                hashtagNodeCtr++;
            }
        }

        public void AddColumn(int index, char symbol)
        {
            Node[,] tmp = nodes;
            nodes = new Node[width + 1, height];
            width++;
            for (int y = 0; y < height; y++)
            {
                //preserve before shift
                for (int x = 0; x < index; x++)
                {
                    nodes[x,y] = tmp[x,y];
                }
                //now do after shift
                for(int x = index; x < width - 1; x++)
                {
                    if (tmp[x,y].ToString() != ".") 
                    {
                        int pos = Convert.ToInt32(tmp[x, y].ToString());
                        Tuple<int, int> tmpCoord = hashtagNodes[pos];
                        hashtagNodes[pos] = new Tuple<int, int>(tmpCoord.Item1 + 1, tmpCoord.Item2);
                    }
                    nodes[x + 1, y] = tmp[x, y];
                }
                nodes[index, y] = new Node(symbol);
            }
        }

        public void AddRow(int index, char symbol) 
        {
            Node[,] tmp = nodes;
            nodes = new Node[width, height + 1];
            height++;
            //preserve below index
            for(int y = 0; y < index; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    nodes[x, y] = tmp[x, y];
                }
            }
            //now shift necessary
            for(int y = index; y < height - 1; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (tmp[x, y].ToString() != ".")
                    {
                        int pos = Convert.ToInt32(tmp[x, y].ToString());
                        Tuple<int, int> tmpCoord = hashtagNodes[pos];
                        hashtagNodes[pos] = new Tuple<int, int>(tmpCoord.Item1, tmpCoord.Item2+1);
                    }
                    nodes[x, y + 1] = tmp[x, y];
                }
            }
            //fill in symbols
            for(int x = 0; x < width; x++)
            {
                nodes[x, index] = new Node(symbol);
            }
        }

        public bool IsColumnOneSymbol(int index)
        {
            bool isColumnOneSymbol = true;
            for (int y = 0; y < height; y++)
            {
                if (nodes[index, y].ToString() != ".") { isColumnOneSymbol = false; y = height; }
            }
            return isColumnOneSymbol;
        }

        public bool IsRowOneSymbol(int index)
        {
            bool isRowOneSymbol = true;
            for (int x = 0; x < width; x++)
            {
                if (nodes[x, index].ToString() != ".") { isRowOneSymbol = false; x = width; }
            }
            return isRowOneSymbol;
        }

        public int DistanceBetween(int nodeOne, int nodeTwo)
        {
            // can't just assume direct distance is equal to shortest path
            Tuple<int,int> startCoord = hashtagNodes[nodeOne];
            List<Tuple<int,int>> toVisit = new List<Tuple<int,int>>();
            List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
            //maps coord to shortest distance
            Dictionary<Tuple<int,int>, int> finalised = new Dictionary<Tuple<int, int>, int>();
            toVisit.Add(startCoord);
            while (!finalised.Contains(hashtagNodes[nodeTwo]))
            {

            }
            return finalised[hashtagNodes[nodeTwo]];
        }
        
        public int Height { get { return height; } set { height = value; } }
        public int Width { get { return width; } set { width = value; } }
        public void PrintGrid()
        {
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Console.Write(nodes[x,y].ToString());
                }
                Console.WriteLine();
            }
        }

        public Tuple<int, int> ConvertIndexToCoord(int index)
        {
            int y = index / width;
            int x = index % width;
            return new Tuple<int, int>(x, y);
        }
    }
}
