﻿namespace Day_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MorteTools.FileParser fp = new MorteTools.FileParser();
            MorteTools.List<string> lines = fp.GetLinesFromTxt("input.txt");
            List<Map> maps = new List<Map>();
            int lineCtr = 0;
            while (lineCtr < lines.Count())
            {
                List<string> tmp = new List<string>();
                while (lineCtr < lines.Count() && lines[lineCtr] != "") 
                {
                    tmp.Add(lines[lineCtr]);
                    lineCtr++;
                }
                maps.Add(new Map(tmp));
                lineCtr++;
            }
            int columnSum = 0;
            int rowSum = 0;
            for (int i = 0; i < maps.Count; i++)
            {
                Console.WriteLine("Map: " + i);
                Map m = maps[i];
                int YWithSmudge = m.FindYAxisReflection();
                if (YWithSmudge > 0) { columnSum += YWithSmudge; }
                else
                {
                    int XWithSmudge = m.FindXAxisReflection();
                    if (XWithSmudge > 0) { rowSum += XWithSmudge; }
                    else
                    {
                        Console.WriteLine("Missing reflection");
                    }
                }
                
            }
            int sum = columnSum + (rowSum * 100);
            Console.WriteLine(sum);
        }
    }
}