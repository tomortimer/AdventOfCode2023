using System.Runtime.CompilerServices;

namespace Day_17
{
    internal class Program
    {
        enum Directions
        {
            Up, // 0
            Right, // 1
            Down, // 2
            Left //3
        }
        static void Main(string[] args)
        {
            MorteTools.List<string> lines = new MorteTools.FileParser().GetLinesFromTxt("input.txt");
            int width = lines[0].Length;
            int height = lines.Count();
            Node[,] grid = new Node[width, height];
            List<Node> nodes = new List<Node>();
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Node tmp = new Node(int.Parse(lines[y][x].ToString()), x, y, 0, 0);
                    grid[x,y] = tmp;
                }
            }
            nodes.Add(new Node(2, 0,0, 1,0));
            nodes.Add(new Node(2, 0, 0, 0, 1));
            nodes[0].distance = 0;
            nodes[1].distance = 0;
            

            Node current;
            List<string> visited = new List<string>();
            //looking for coord (12,12)
            Tuple<int, int> end = new Tuple<int, int>(width - 1, height -1);
            do
            {
                nodes = nodes.OrderBy(x => x.distance).ToList();
                current = nodes[0];
                nodes.RemoveAt(0);
                if (!visited.Contains(current.ToString()) && NodeInBounds(current, width, height))
                {
                    visited.Add(current.ToString());
                    if (NodeInBounds(current, width, height))
                    {
                        if (current.stepCtr > 3)
                        {//branch turns here
                            nodes.Add(new Node(grid[current.x, current.y].cost, current.x, current.y, current.yTrans, -current.xTrans));
                            nodes.Last().distance = current.distance;
                            nodes.Last().history = current.history.Clone();
                            nodes.Last().Move(grid);
                            nodes.Add(new Node(grid[current.x, current.y].cost, current.x, current.y, -current.yTrans, current.xTrans));
                            nodes.Last().distance = current.distance;
                            nodes.Last().history = current.history.Clone();
                            nodes.Last().Move(grid);

                        }

                        //keep going straight if less then 3 consecutive steps
                        if (current.stepCtr < 10)
                        {
                            nodes.Add(new Node(grid[current.x, current.y].cost, current.x, current.y, current.xTrans, current.yTrans));
                            nodes.Last().stepCtr = current.stepCtr;
                            nodes.Last().distance = current.distance;
                            nodes.Last().history = current.history.Clone();
                            nodes.Last().Move(grid);
                        }
                    }
                }
                
            }while(!(current.x == width - 1 && current.y == height - 1 && current.stepCtr > 3));

            Console.WriteLine(current.distance);
            //Console.WriteLine(current.history.ToString());
        }

        static bool NodeInBounds(Node node, int width, int height)
        {
            bool ret = false;
            if(node.x >= 0 && node.x < width && node.y >= 0 && node.y < height) { ret  = true; }
            return ret;
        }
    }
}
