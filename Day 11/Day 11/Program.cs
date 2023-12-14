using System;
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
            grid.InsertColumn(3, '.');
            grid.PrintGrid();
        }
    }
}
