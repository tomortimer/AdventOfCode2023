using System;
using System.ComponentModel.DataAnnotations;
using MorteTools;
namespace Day_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            Map grid = new Map(lines);
            /*Console.WriteLine("Before:");
            grid.PrintGrid();*/
            grid.RollAllNorth();
            /*Console.WriteLine("After:");
            grid.PrintGrid();*/
            Console.WriteLine("Part One: " + grid.CalcScore());
            System.Collections.Generic.List<string> results = new System.Collections.Generic.List<string>();
            int ctr = 0;
            string tmp = "";
            bool cont = true;
            int firstInstance = 0;
            //CALCULATED CYCLE PERIOD OF 59
            int offset = (1000000000 % 59);
            //go until first repetition
            do
            {
                results.Add(tmp);
                grid.SpinCycle();
                ctr++;
                //Console.WriteLine("Cycle: " + ctr);
                if((ctr - offset) % 59 == 0) { Console.WriteLine(grid.CalcScore()); }
                tmp = grid.ToString();
                if(results.Contains(tmp) && 1000000000 % (ctr+1) == 0) 
                { 
                    //cont = false;
                    firstInstance = results.IndexOf(tmp);
                }
            } while (ctr < 1000000000);
            Console.WriteLine("Part Two: " + grid.CalcScore());
            Console.WriteLine("First occurence: " + firstInstance);
            Console.WriteLine("Secon occurence: 199");
            Console.WriteLine("Period = "+(199 - firstInstance));
            //grid.PrintGrid();
        }
    }
}
