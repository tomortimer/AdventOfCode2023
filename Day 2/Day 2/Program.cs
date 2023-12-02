using System;
using MorteTools;
using System.Text.RegularExpressions;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            int sum = 0;

            for(int i = 0; i < lines.Count(); i++) 
            {
                string[] idSeparated = lines[i].Split(':');
                int gameID = Convert.ToInt32(idSeparated[0].Substring(5));
                string[] handfuls = idSeparated[1].Split(";");
                bool valid = true;
                int highestBlue = 1;
                int highestGreen = 1;
                int highestRed = 1;
                foreach (string group in handfuls)
                {
                    MatchCollection mc = Regex.Matches(group, "([0-9]+) (red|blue|green)");
                    foreach(Match match in mc)
                    {
                        int number = Convert.ToInt32(match.Groups[1].Value);
                        string colour = match.Groups[2].Value;
                        //int max = 0;
                        switch (colour)
                        {
                            case "blue":
                                if(number > highestBlue) { highestBlue = number; }
                                //max = 14;
                                break;
                            case "red":
                                if (number > highestRed) { highestRed = number; }
                                //max = 12;
                                break;
                            case "green":
                                if (number > highestGreen) { highestGreen = number; }
                                //max = 13;
                                break;
                        }
                        /*if (number > max)
                        {
                            valid = false;
                        }*/
                    }
                    
                }
                int power = highestBlue * highestGreen * highestRed;
                sum += power;
                /*if(valid)
                {
                    sum += gameID;
                }*/
            }

            Console.WriteLine(sum);
        }
    }
}
