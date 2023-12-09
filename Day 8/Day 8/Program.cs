using System;
using MorteTools;
using System.Text.RegularExpressions;
using System.Linq;
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
                Node tmp = new Node(nodeName, leftAndRight[0].GetHashCode(), leftAndRight[1].GetHashCode());
                map.Add(nodeName.GetHashCode(), tmp);
            }
            //int currentNode = "AAA".GetHashCode();
            List<int> currentNodes = new List<int>();
            //my original part 2 solution took so long to run I thought of an efficient one in that time 
            foreach (KeyValuePair<int, Node> pair in map)
            {
                string name = pair.value.GetName();
                Console.WriteLine(name);
                if (name[2] == 'A') { currentNodes.Add(pair.value.GetName().GetHashCode()); }
            }
            List<long> pathLengths = new List<long>();
            foreach (int node in currentNodes)
            {
                int ctr = 0;
                int currentNode = node;
                while (map[currentNode].GetName()[2] != 'Z')
                {
                    int strIndex = ctr % directions.Length;
                    switch (directions[strIndex])
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
                pathLengths.Add(ctr);
            }
            long moves = pathLengths.Aggregate<long>(LCM);
            Console.WriteLine(moves);
        }

        static long GCD(long a, long b)
        {
            long remainder;
            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }

        static long LCM(long a, long b)
        {
            //use the GCD-LCM relationship
            long lcm = (a*b) / GCD(a, b);
            return lcm;
        }
    }
}
