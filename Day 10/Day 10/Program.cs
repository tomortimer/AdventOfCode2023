using System;
using MorteTools;
namespace Day_10
{
    enum Directions
    {
        North, // 0
        East, // 1
        South, // 2
        West // 3
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            Pipe[,] pipes = new Pipe[lines[0].Length, lines.Count()];
            Tuple<int, int> startIndex = new Tuple<int, int>(0,0);
            for(int y = 0; y < lines.Count(); y++)
            {
                for(int x = 0;  x < lines[y].Length; x++)
                {
                    pipes[x, y] = new Pipe(lines[y][x]);
                    if (lines[y][x] == 'S') 
                    { 
                        startIndex = new Tuple<int, int>(x, y);
                    }
                }
            }
            // now infer type of pipe
            bool connectsWest = false;
            bool connectsEast = false;
            bool connectsNorth = false;
            bool connectsSouth = false;
            if (startIndex.Item1 != 0) { connectsWest = pipes[startIndex.Item1 - 1, startIndex.Item2].ConnectsEast(); }
            if(startIndex.Item1 != lines[0].Length - 1) { connectsEast = pipes[startIndex.Item1 + 1, startIndex.Item2].ConnectsWest(); }
            if(startIndex.Item2 != 0) { connectsNorth = pipes[startIndex.Item1, startIndex.Item2 - 1].ConnectsSouth(); }
            if(startIndex.Item2 != lines.Count() -1) { connectsSouth = pipes[startIndex.Item1, startIndex.Item2 + 1].ConnectsNorth(); }

            if (connectsNorth && connectsEast) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('|'); }
            else if (connectsNorth && connectsSouth) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('L'); }
            else if (connectsNorth && connectsWest) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('J'); }
            else if (connectsEast && connectsSouth) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('F'); }
            else if (connectsEast && connectsWest) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('-'); }
            else if (connectsSouth && connectsWest) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('7'); }

            //find loop
            List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
            Dictionary<Tuple<int, int>, int> tmp = RecursiveTraverse(visited, startIndex, lines[0].Length, lines.Count(), pipes, 0);
            foreach(var pair in tmp)
            {
                Console.WriteLine(pipes[pair.key.Item1, pair.key.Item2].ToString() + " X: "+pair.key.Item1+" Y: "+pair.key.Item2+" Distance: "+pair.value);
            }
        }
        
        static Dictionary<Tuple<int,int> ,int> RecursiveTraverse(List<Tuple<int,int>> visited, Tuple<int,int> current, int xBound, int yBound, Pipe[,] pipes, int distance)
        {
            Dictionary<Tuple<int, int>, int> distances = new Dictionary<Tuple<int, int>, int>();
            distances.Add(current, distance); 
            distance++;
            visited.Add(current);
            Tuple<int, int> transformOneCoord = pipes[current.Item1, current.Item2].Traverse(current).Item1;
            Tuple<int, int> transformTwoCoord = pipes[current.Item1, current.Item2].Traverse(current).Item2;
            
            if (transformOneCoord.Item1 > -1 && transformOneCoord.Item1 < xBound && transformOneCoord.Item2 > -1 && transformOneCoord.Item2 < yBound && (!visited.Contains(transformOneCoord) || (distances.Contains(transformOneCoord) && distances[transformOneCoord] < distance)))
            {
                Dictionary<Tuple<int, int>, int> tmp = RecursiveTraverse(visited, transformOneCoord, xBound, yBound, pipes, distance);
                foreach (var pair in tmp)
                {
                    distances.Add(pair.key, pair.value);
                }
            }
            if (transformTwoCoord.Item1 > -1 && transformTwoCoord.Item1 < xBound && transformTwoCoord.Item2 > -1 && transformTwoCoord.Item2 < yBound && (!visited.Contains(transformTwoCoord) || (distances.Contains(transformTwoCoord) && distances[transformTwoCoord] < distance)))
            {
                Dictionary<Tuple<int, int>, int> tmp = RecursiveTraverse(visited, transformTwoCoord, xBound, yBound, pipes, distance);
                foreach (var pair in tmp)
                {
                    distances.Add(pair.key, pair.value);
                }
            }

            return distances;

        }
    }
}
