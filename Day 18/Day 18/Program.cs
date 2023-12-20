using System.Numerics;

namespace Day_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MorteTools.List<string> lines = new MorteTools.FileParser().GetLinesFromTxt("input.txt");
            Grid lagoon = new Grid();
            Tuple<long, long> current = new Tuple<long, long>(0,0);
            Dictionary<string, Tuple<long, long>> transformations = new Dictionary<string, Tuple<long, long>> 
            {
                {"R", new Tuple<long, long>(1,0) },
                {"U", new Tuple < long, long >(0,-1)},
                {"D", new Tuple < long, long >(0,1)},
                {"L", new Tuple < long, long >(-1,0)}
            };
            List<Tuple<long, long>> vertices = new List<Tuple<long,long>>();
            long perimeter = 0;
            foreach(string line in lines)
            {
                vertices.Add(current);
                /*string direction = line.Split(' ')[0];
                int moves = Convert.ToInt32(line.Split(' ')[1]);*/
                long moves = Convert.ToInt32(line.Split('#')[1].Substring(0, 5), 16);
                int dirInt = Convert.ToInt32(line.Split('#')[1].Trim(')').Last().ToString(), 16);
                string direction = "";
                switch (dirInt)
                {
                    case 0: direction = "R"; break;
                    case 1: direction = "D"; break;
                    case 2: direction = "L"; break;
                    case 3: direction = "U"; break;
                }
                current = new Tuple<long,long>(current.Item1 + transformations[direction].Item1 * moves, current.Item2 + transformations[direction].Item2 * moves);
                perimeter += moves;
                //offset for enabling part 2
                /*for(int i = 0;  i < moves; i++)
                {
                    current += transformations[direction];
                    current = lagoon.AddChar((int)current.X, (int)current.Y, '#');
                }*/
                
            }
            /*Vector2 tmp = lagoon.GetStartCoord();
            tmp = new Vector2(tmp.X + 1, tmp.Y + 1);
            lagoon.Flood(tmp);
            //lagoon.PrintGrid();
            Console.WriteLine(lagoon.CountChar('#'));*/
            long area = AreaFromVertices(vertices);
            area += perimeter / 2 + 1;
            Console.WriteLine(area);
        }

        static long AreaFromVertices(List<Tuple<long, long>> vertices)
        {
            long area = 0;
            for(int i = 0; i < vertices.Count; i++) 
            {
                int next = (i + 1) % vertices.Count;
                int last = i - 1;
                if(last < 0) { last = vertices.Count - 1; }
                //using shoelace adaptation of area of any polygon
                long value = (long)(vertices[i].Item2 * (vertices[next].Item1 - vertices[last].Item1));
                area += value;
            }
            area = Math.Abs(area) / 2;
            return area;
        }
    }
}
