using System;
using System.Transactions;
using System.Collections.Generic;
using MorteTools;
using System.IO;
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
            MorteTools.List<string> lines = fp.GetLinesFromTxt("input.txt");
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

            if (connectsNorth && connectsSouth) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('|'); }
            else if (connectsNorth && connectsEast) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('L'); }
            else if (connectsNorth && connectsWest) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('J'); }
            else if (connectsEast && connectsSouth) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('F'); }
            else if (connectsEast && connectsWest) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('-'); }
            else if (connectsSouth && connectsWest) { pipes[startIndex.Item1, startIndex.Item2] = new Pipe('7'); }

            
            int xBound = lines[0].Length;
            int yBound = lines.Count();
            System.Collections.Generic.List<Tuple<int,int>> visited = new System.Collections.Generic.List<Tuple<int, int>> ();
            Tuple<int, int> current = startIndex;
            Tuple<int,int> endNode = pipes[current.Item1, current.Item2].Traverse(current).Item2;
            //exit if distance is greater and node is already visited
            int distance = 1;
            do
            {
                visited.Add(current);
                Tuple<int, int> next = pipes[current.Item1, current.Item2].Traverse(current).Item1;
                if (visited.Contains(next))
                {
                    next = pipes[current.Item1, current.Item2].Traverse(current).Item2;
                }
                current = next;
                distance++;

            } while (!current.Equals(endNode));

            /*Console.WriteLine(distance/2);
            Console.WriteLine((double)visited.Count / 2f);
            Console.WriteLine("Start: "+startIndex.Item1+","+startIndex.Item2);
            Console.WriteLine("Start Type: " + pipes[startIndex.Item1, startIndex.Item2]);
            Console.WriteLine("End: "+endNode.Item1+","+endNode.Item2);*/


            StreamWriter writer = new StreamWriter("output.txt");
            for (int y = 0; y < yBound; y++)
            {
                for (int x = 0; x < xBound; x++)
                {
                    if (visited.Contains(new Tuple<int, int>(x, y))) 
                    {
                        if (lines[y][x] == 'S') { writer.Write(pipes[x, y].ToString()); }
                        else { writer.Write(Convert.ToString(lines[y][x])); }
                    }
                    else
                    {
                        writer.Write(".");
                    }
                }
                writer.WriteLine();
            }
            writer.Close();
            //this looks super cool just needed an idea of the puzzle

            //part two stuff
            //need to have a left hand and right hand side of path somehow??
            //selective flooding maybe?
            // ideq: expand grid, like zoom in so each symbol is now 3x3 then flood from a chosen point, should work in theory. as long as chosen point is right. then count the number of flooded blank 3x3s?
            lines = fp.GetLinesFromTxt("output.txt");
            Pipe[,] expandedPipes = new Pipe[lines[0].Length*3, lines.Count() * 3];
            int yPos = 0; int xPos = 0;
            for(int y = 0; y < lines.Count(); y++)
            {
                for(int x = 0;x < lines[0].Length; x++)
                {
                    expandedPipes[xPos, yPos] = new Pipe('.');
                    if (lines[y][x] == 'L' || lines[y][x] == '|' || lines[y][x] == 'J') { expandedPipes[xPos + 1, yPos] = new Pipe('|'); }
                    else { expandedPipes[xPos + 1, yPos] = new Pipe('.'); }
                    expandedPipes[xPos+2, yPos] = new Pipe('.');
                    if (lines[y][x] == '-' || lines[y][x] == '7' || lines[y][x] == 'J') { expandedPipes[xPos, yPos+1] = new Pipe('-'); }
                    else { expandedPipes[xPos, yPos+1] = new Pipe('.'); }
                    expandedPipes[xPos+1, yPos+1] = new Pipe(lines[y][x]);
                    if (lines[y][x] == 'F' || lines[y][x] == '-' || lines[y][x] == 'L') { expandedPipes[xPos + 2, yPos+1] = new Pipe('-'); }
                    else { expandedPipes[xPos + 2, yPos+1] = new Pipe('.'); }
                    expandedPipes[xPos, yPos + 2] = new Pipe('.');
                    if (lines[y][x] == '7' || lines[y][x] == '|' || lines[y][x] == 'F') { expandedPipes[xPos + 1, yPos+2] = new Pipe('|'); }
                    else { expandedPipes[xPos + 1, yPos+2] = new Pipe('.'); }
                    expandedPipes[xPos + 2, yPos + 2] = new Pipe('.');
                    xPos += 3;
                }
                yPos += 3;
            }
        }

        static bool InBounds(Tuple<int,int> pos, int xBound, int yBound)
        {
            bool ret = false;
            if(-1 < pos.Item1 && pos.Item1 < xBound && -1 < pos.Item2 && pos.Item2 < yBound) { ret = true; }
            return ret;
        }
    }
}
