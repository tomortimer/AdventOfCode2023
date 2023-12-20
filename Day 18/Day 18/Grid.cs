using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day_18
{
    internal class Grid
    {
        char[,] grid;
        int width;
        int height;
        Vector2 trackStartCoord;

        public Grid()
        {
            width = 1;
            height = 1;
            grid = new char[width, height];
            grid[0, 0] = '#';
            trackStartCoord = new Vector2(0, 0);
        }
        public Vector2 GetStartCoord() { return trackStartCoord; }

        public Vector2 AddChar(int x, int y,  char c)
        {
            if(x < 0) { AddColumnLeft(); x++; }
            else if(x >= width) { AddColumnRight(); }
            if (y < 0) { AddRowTop(); y++; }
            else if(y >= height) {  AddRowBottom(); }
            grid[x, y] = c;
            Vector2 coord = new Vector2(x, y);
            return coord;
        }
        public Vector2 FindFloodPoint(char c)
        {
            Vector2 current = new Vector2(0,0);
            for(int x = 1; x < width-1; x++)
            {
                for(int y = 1; y < height-1; y++)
                {
                    current = new Vector2(x, y);
                    int ctr = 0;
                    for(int i = x; i < width; i++)
                    {
                        if (c == grid[i, y]) { ctr++; }
                    }
                    if(ctr % 2 == 1)
                    {
                        y = height; x = width;
                    }
                }
            }
            return current;
        }

        public void Flood(Vector2 start)
        {
            Queue<Vector2> floodQueue = new Queue<Vector2>();
            floodQueue.Enqueue(start);
            while(floodQueue.Count > 0)
            {
                Vector2 current = floodQueue.Dequeue();
                grid[(int)current.X, (int)current.Y] = '#';
                if (grid[(int)current.X + 1, (int)current.Y] != '#' && !floodQueue.Contains(new Vector2(current.X + 1, current.Y))) { floodQueue.Enqueue(new Vector2(current.X + 1, current.Y)); }
                if(grid[(int)current.X - 1, (int)current.Y] != '#' && !floodQueue.Contains(new Vector2(current.X - 1, current.Y))) { floodQueue.Enqueue(new Vector2(current.X - 1, current.Y));}
                if (grid[(int)current.X, (int)current.Y + 1] != '#' && !floodQueue.Contains(new Vector2(current.X, current.Y + 1))) { floodQueue.Enqueue(new Vector2(current.X, current.Y+1)); }
                if (grid[(int)current.X, (int)current.Y - 1] != '#' && !floodQueue.Contains(new Vector2(current.X, current.Y - 1))) { floodQueue.Enqueue(new Vector2(current.X, current.Y-1)); }
            }
        }

        public int CountChar(char c)
        {
            int count = 0;
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    if (grid[x, y] == c) { count++; }
                }
            }
            return count;
        }

        private void AddColumnRight()
        {
            char[,] tmp = grid;
            grid = new char[width + 1, height];
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    grid[x,y] = tmp[x,y];
                }
            }
            for(int y = 0; y < height; y++)
            {
                grid[width, y] = '.';
            }
            width++;
        }
        private void AddColumnLeft()
        {
            char[,] tmp = grid;
            grid = new char[width + 1, height];
            for(int x = 1; x <= width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    grid[x,y] = tmp[(x-1), y];
                }
            }
            for(int y = 0; y < height; y++)
            {
                grid[0, y] = '.';
            }
            width++;
            trackStartCoord = new Vector2(trackStartCoord.X + 1, trackStartCoord.Y);
        }
        private void AddRowBottom()
        {
            char[,] tmp = grid;
            grid = new char[width, height + 1];
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    grid[x, y] = tmp[x, y];
                }
            }
            for(int x = 0; x < width; x++)
            {
                grid[x, height] = '.';
            }
            height++;
        }
        private void AddRowTop()
        {
            char[,] tmp = grid;
            grid = new char[width, height + 1];
            for(int x = 0; x < width; x++)
            {
                for(int y = 1; y <= height; y++)
                {
                    grid[x,y] = tmp[x, (y-1)];
                }
            }
            for(int x = 0; x < width; x++)
            {
                grid[x, 0] = '.';
            }
            height++;
            trackStartCoord = new Vector2(trackStartCoord.X, trackStartCoord.Y + 1);
        }

        public void PrintGrid()
        {
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Console.Write(grid[x,y]);
                }
                Console.WriteLine();
            }
        }

    }
}
