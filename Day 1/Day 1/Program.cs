using System;
using System.Text.RegularExpressions;
using MorteTools;

namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser reader = new FileParser();
            List<string> lines = reader.GetLinesFromTxt("input.txt");
            int sum = 0;
            
            for(int i = 0; i < lines.Count(); i++)
            {
                //MatchCollection mc = Regex.Matches(lines[i], "[1-9]");
                //positive look ahead goes off here
                MatchCollection mc = Regex.Matches(lines[i], "(?=([1-9]|one|two|three|four|five|six|seven|eight|nine|eleven|twelve|thirteen))");
                //convert mc to list
                List<string> integers = new List<string>();
                for(int j = 0; j < mc.Count; j++)
                {
                    //unpick the multi group capturing regex
                    string tmp = "";
                    if (Regex.IsMatch(mc[j].Groups[1].Value, "[1-9]"))
                    {
                        tmp = mc[j].Groups[1].Value;
                    }
                    else
                    {
                        tmp = mc[j].Groups[0].Value + mc[j].Groups[1].Value;
                    }
                    switch (tmp)
                    {
                        case "one":
                            integers.Add("1");
                            break;
                        case "two":
                            integers.Add("2");
                            break;
                        case "three":
                            integers.Add("3");
                            break;
                        case "four":
                            integers.Add("4");
                            break;
                        case "five":
                            integers.Add("5");
                            break;
                        case "six":
                            integers.Add("6");
                            break;
                        case "seven":
                            integers.Add("7");
                            break;
                        case "eight":
                            integers.Add("8");
                            break;
                        case "nine":
                            integers.Add("9");
                            break;
                        case "eleven":
                            integers.Add("1");
                            break;
                        case "twelve":
                            integers.Add("2");
                            break;
                        case "thirteen":
                            integers.Add("3");
                            break;
                        default:
                            integers.Add(tmp);
                            break;
                    }
                }
                string twoDigitNum = integers[0] + integers[integers.Count() - 1];
                sum += Convert.ToInt32(twoDigitNum);
            }
            Console.WriteLine(sum);
        }
    }
}
