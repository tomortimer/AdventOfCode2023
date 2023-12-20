using System.Numerics;

namespace Day_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MorteTools.List<string> lines = new MorteTools.FileParser().GetLinesFromTxt("input.txt");
            Grid lagoon = new Grid();
            Vector2 current = new Vector2(0,0);
            Dictionary<string, Vector2> transformations = new Dictionary<string, Vector2> 
            {
                {"R", new Vector2(1,0) },
                {"U", new Vector2(0,-1)},
                {"D", new Vector2(0,1)},
                {"L", new Vector2(-1,0)}
            };
            foreach(string line in lines)
            {
                string direction = line.Split(' ')[0];
                int moves = int.Parse(line.Split(' ')[1]);
                for(int i = 0;  i < moves; i++)
                {
                    current += transformations[direction];
                    current = lagoon.AddChar((int)current.X, (int)current.Y, '#');
                }
            }
            //lagoon.PrintGrid();
            //Console.WriteLine("----------------------");
            Vector2 tmp = lagoon.GetStartCoord();
            tmp = new Vector2(tmp.X + 1, tmp.Y + 1);
            lagoon.Flood(tmp);
            //lagoon.PrintGrid();
            Console.WriteLine(lagoon.CountChar('#'));
        }
    }
}
