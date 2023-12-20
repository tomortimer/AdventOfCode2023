using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_18
{
    enum Directions
    {
        Up, Right, Down, Left
    }
    internal class Node<T>
    {
        Node<T> up;
        Node<T> down;
        Node<T> left;
        Node<T> right;
        T value;
        Tuple<int, int> coord;

        public Node(Tuple<int,int> coord, T value)
        {
            this.coord = coord;
            this.value = value;
            up = null;
            down = null;
            left = null;
            right = null;
        }

        public void ConnectNode(Node<T> node, int dir) 
        {
            switch (dir)
            {
                case (int)Directions.Up: up = node; break;
                case (int)Directions.Right: right = node; break;
                case (int)Directions.Down: down = node; break;
                case (int)Directions.Left: left = node; break;
            }
        }

        
    }
}
