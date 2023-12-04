using System;
using System.Text.RegularExpressions;
using MorteTools;

namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser parser = new FileParser();
            //List<string> lines = parser.GetLinesFromTxtTrimmed("input.txt", 7);
            List<string> lines = parser.GetLinesFromTxt("input.txt");
            List<int> scoreDict = new List<int>();
            int sum = 0;
            for (int i = 0; i < lines.Count(); i++) 
            {
                int numMatches = 0;
                int cardIndex = Convert.ToInt32(Regex.Match(lines[i], "[0-9]+").Groups[0].Value) - 1;
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
                scoreDict.Add(numMatches);
                /*if(numMatches > 0) 
                {
                    //sum += (int)Math.Pow(2.0, numMatches);
                    for(int x = 1; x <= numMatches; x++)
                    {
                        lines.Add(lines[cardIndex + x]);
                        Console.WriteLine("Card " + (cardIndex+1) + " adds Card " + (cardIndex + x+ 1));
                    }
                }*/
            }
            //Console.WriteLine(sum)
            List<int> copies = new List<int>();
            for(int i = 0; i < lines.Count();  i++)
            {
                copies.Add(1);
            }
            for(int i = 0; i < lines.Count(); i++)
            {
                for(int y = 0; y < scoreDict[i]; y++)
                {
                    copies[i + y + 1] += copies[i];
                }
                sum += copies[i];
            }
            Console.WriteLine(sum);
        }
    }
}
