using System;

namespace Day_8
{
    class Node
    {
        string name;
        private int left;
        private int right;
        public Node(string nodeName, int leftHash, int rightHash) 
        {
            name = nodeName;
            left = leftHash;
            right = rightHash;
        }

        public int TraverseLeft() { return left; }
        public int TraverseRight() { return right; }
        public string GetName() { return name; }
    }
}
