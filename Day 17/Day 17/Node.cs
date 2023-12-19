using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
    enum Directions
    {
        Up, Right, Down, Left
    }
    internal class Node
    {
        public int cost;
        public int distance;
        public int x;
        public int y;

        public int stepCtr;
        public int direction;

        public int xTrans;
        public int yTrans;

        public Node(int cost, int x, int y, int xTrans, int yTrans) 
        {
            this.cost = cost;
            distance = 100000;
            this.x = x;
            this.y = y;
            this.xTrans = xTrans;
            this.yTrans = yTrans;
            stepCtr = 0;
        }

        public override string ToString()
        {
            UpdateDirection();
            return "X:" + x + "Y:" + y + "Dir:" + direction+"Stp:"+stepCtr;
        }

        private void UpdateDirection()
        {
            if(xTrans == 1) { direction = (int)Directions.Right; }
            else if(xTrans == -1) { direction = (int)Directions.Left; }
            else if (yTrans == 1) { direction = (int)Directions.Down; }
            else if(yTrans == -1) { direction = (int)Directions.Up; }
        }

        public void Move(Node[,] grid)
        {
            x += xTrans;
            y += yTrans;
            stepCtr++;
            if(NodeInBounds(this, grid.GetLength(0), grid.GetLength(1))) { 
                distance += grid[x, y].cost; }
        }
        private bool NodeInBounds(Node node, int width, int height)
        {
            bool ret = false;
            if (node.x >= 0 && node.x < width && node.y >= 0 && node.y < height) { ret = true; }
            return ret;
        }
    }
}
