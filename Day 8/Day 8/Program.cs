using System;
using MorteTools;
using System.Text.RegularExpressions;
namespace Day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Node> map = new Dictionary<int, Node>();
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            string directions = lines[0];
            for(int i = 1; i < lines.Count();  i++)
            {
                string nodeName = lines[i].Remove(3);
                string[] leftAndRight = Regex.Replace(lines[i].Substring(7, 8), " ", string.Empty).Split(',');
                Node tmp = new Node(leftAndRight[0].GetHashCode(), leftAndRight[1].GetHashCode());
                map.Add(nodeName.GetHashCode(), tmp);
            }
            int currentNode = "AAA".GetHashCode();
            int ctr = 0;
            while(currentNode != "ZZZ".GetHashCode()) 
            {
                int strIndex = ctr % directions.Length;
                switch(directions[strIndex])
                {
                    case 'R':
                        currentNode = map[currentNode].TraverseRight();
                        break;
                    case 'L':
                        currentNode = map[currentNode].TraverseLeft();
                        break;
                }
                ctr++;
            }
            Console.WriteLine(ctr);
        }
    }
}
