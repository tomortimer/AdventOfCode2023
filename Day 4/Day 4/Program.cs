using System;
using MorteTools;

namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser parser = new FileParser();
            List<string> lines = parser.GetLinesFromTxtTrimmed("input.txt", 7);
            int sum = 0;
            for(int i = 0; i < lines.Count(); i++) 
            {
                double numMatches = -1;
                string line = lines[i].Replace("  ", " ");
                string[] halves = line.Split('|');
                string[] leftNums = halves[0].Substring(1).Split(" ");
                List<string> winningNums = new List<string>(halves[1].Substring(1).Split(" "));
                foreach(string num in leftNums)
                {
                    if (winningNums.Contains(num))
                    {
                        numMatches++;
                    }
                }
                if(numMatches >= 0) { sum += (int)Math.Pow(2.0, numMatches); }
            }
            Console.WriteLine(sum);
        }
    }
}
