using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using MorteTools;

namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this solution feels like a super cheat shot, there really must be a better way
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            /*MatchCollection times = Regex.Matches(lines[0], "[0-9]+");
            //MatchCollection distances = Regex.Matches(lines[1], "[0-9]+");
            for(int x = 0; x < 4; x++)
            {
                int time = Convert.ToInt32(times[x].Value);
                int distanceToBeat = Convert.ToInt32(distances[x].Value);
                int ctr = 0;
                for(int speed = 0; speed < time; speed++)
                {
                    int remainingTime = time - speed;
                    int distance = remainingTime * speed;
                    if(distance >= distanceToBeat) { ctr++; }
                }
                product *= ctr;
            }
            Console.WriteLine(product);*/

            /*wrote this one out physically, to work through, so I don't do a repeat of day 5 lol
            h = time held
            t = total time
            d = distance
            h(t-h) = d
            t is known, h is var, and make an inequality in terms of known d
            -h^2 + ht > d
            h^2 -ht +d > 0
            then find roots
            */
            long time = Convert.ToInt64(Regex.Match(lines[0], "[0-9]+").Value);
            long distance = Convert.ToInt64(Regex.Match(lines[1], "[0-9]+").Value);
            // for quadratic ax^2 + bx + c = 0; a = 1, b = -time, c = distance
            long rootOne = (time + (long)Math.Sqrt(Math.Pow(time, 2) - 4 * distance)) / 2;
            long rootTwo = (time - (long)Math.Sqrt(Math.Pow(time, 2) - 4 * distance)) / 2;
            long solutions = rootOne - rootTwo;
            Console.WriteLine(solutions);
        }
    }
}
