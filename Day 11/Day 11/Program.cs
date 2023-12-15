using System;
using System.ComponentModel;
using MorteTools;
namespace Day_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            Grid grid = new Grid(lines[0].Length, lines.Count());
            for(int y = 0; y < grid.Height;  y++)
            {
                for(int x = 0; x < grid.Width; x++)
                {
                    grid.AddNode(lines[y][x], x, y);
                }
            }
            
            //expand rows if necessary
            for(int y = 0; y < grid.Height; y++) 
            {
                if (grid.IsRowOneSymbol(y)) { grid.AddRow(y, '.'); Console.WriteLine("Expanded Row: " + y);y++; }
            }
            //expand columns if necessary
            for(int x = 0; x < grid.Width; x++)
            {
                if (grid.IsColumnOneSymbol(x)) { grid.AddColumn(x, '.'); Console.WriteLine("Expanded Column: " + x);x++; }
            }

            grid.PrintGrid();
            System.Collections.Generic.List<Tuple<int, int>> pairs = GenerateUniquePairs(grid.GetNumSigNodes());
            int sum = 0;
            foreach(Tuple<int, int> pair in pairs)
            {
                sum += grid.DistanceBetween(pair.Item1, pair.Item2);
            }
            Console.WriteLine(sum);

        }

        static System.Collections.Generic.List<Tuple<int, int>> GenerateUniquePairs(int max)
        {
            System.Collections.Generic.List<Tuple<int,int>> ret = new System.Collections.Generic.List<Tuple<int,int>>();
            for(int x = 0; x<max; x++)
            {
                for(int y = 0; y<max ; y++)
                {
                    Tuple<int,int> tmp = new Tuple<int,int>(x,y);
                    Tuple<int, int> tmp2 = new Tuple<int, int>(y, x);
                    if (!ret.Contains(tmp) && x!=y && !ret.Contains(tmp2)) { ret.Add(tmp);}
                }
            }
            return ret;
        }
    }
}
