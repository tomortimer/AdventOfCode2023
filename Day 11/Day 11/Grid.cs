﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using MorteTools;
namespace Day_11
{
    internal class Grid
    {
        private Node[,] nodes;
        Dictionary<int, Tuple<int,int>> hashtagNodes;
        System.Collections.Generic.List<int> expandedColumns;
        System.Collections.Generic.List<int> expandedRows;
        int width;
        int height;
        int hashtagNodeCtr;
        int expansionRate;
        public Grid(int width, int height, int expansion)
        {
            this.width = width;
            this.height = height;
            nodes = new Node[width, height];
            hashtagNodes = new Dictionary<int, Tuple<int,int>>();
            hashtagNodeCtr = 0;
            expandedColumns = new System.Collections.Generic.List<int>();
            expandedRows = new System.Collections.Generic.List<int>();
            expansionRate = expansion;
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
                nodes[x, y] = new Node(Convert.ToInt32(hashtagNodeCtr.ToString()));
                hashtagNodeCtr++;
            }
        }

        public void AddColumn(int index, char symbol)
        {
            Node[,] tmp = nodes;
            for (int y = 0; y < height; y++)
            {
                //shift when greater
                for(int x = index; x < width; x++)
                {
                    if (tmp[x,y].ToString() != ".") 
                    {
                        int pos = Convert.ToInt32(tmp[x, y].ToString());
                        Tuple<int, int> tmpCoord = hashtagNodes[pos];
                        hashtagNodes[pos] = new Tuple<int, int>(tmpCoord.Item1 + expansionRate - 1, tmpCoord.Item2);
                    }
                }
                
            }
        }

        public void AddRow(int index, char symbol) 
        {
            Node[,] tmp = nodes;
            
            //now shift necessary
            for(int y = index; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (tmp[x, y].ToString() != ".")
                    {
                        int pos = Convert.ToInt32(tmp[x, y].ToString());
                        Tuple<int, int> tmpCoord = hashtagNodes[pos];
                        hashtagNodes[pos] = new Tuple<int, int>(tmpCoord.Item1, tmpCoord.Item2+expansionRate-1);
                    }
                }
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

        public long DistanceBetween(int nodeOne, int nodeTwo)
        {
            Tuple<int,int> nodeOneCoord = hashtagNodes[nodeOne];
            Tuple<int,int> nodeTwoCoord = hashtagNodes[nodeTwo];
            long xDiff = Math.Abs(nodeOneCoord.Item1 -  nodeTwoCoord.Item1);
            long yDiff = Math.Abs(nodeOneCoord.Item2 - nodeTwoCoord.Item2);
            long total = xDiff + yDiff;
            return total;
        }

        public int GetNumSigNodes()
        {
            return hashtagNodes.Count();
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
