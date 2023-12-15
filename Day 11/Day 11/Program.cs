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
            Console.WriteLine(grid.DistanceBetween(0, 6));
        }
    }
}
