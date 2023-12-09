using System;

namespace Day_8
{
    class Node
    {
        private int left;
        private int right;
        public Node(int leftHash, int rightHash) 
        {
            left = leftHash;
            right = rightHash;
        }

        public int TraverseLeft() { return left; }
        public int TraverseRight() { return right; }

    }
}
