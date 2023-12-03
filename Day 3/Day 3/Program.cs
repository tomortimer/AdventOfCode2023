using System;
using MorteTools;
using System.Text.RegularExpressions;
namespace Day_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            //convert to 2d array
            char[,] schematic = new char[lines[0].Length, lines.Count()];
            //map file onto schematic
            for(int y = 0; y < lines.Count(); y++)
            {
                for(int x = 0; x < lines[0].Length; x++)
                {
                    schematic[x, y] = lines[y][x];
                }
            }

            int sum = 0;
            for(int i = 0; i < lines.Count(); i++)
            {
                //check when not number or dot is easier
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '*')
                    {
                        List<string> nums = new List<string>();
                        //move around symbol coord
                        for(int x = -1; x <= 1; x++)
                        {
                            for(int y = -1; y <= 1; y++)
                            {
                                Tuple<int, int> coord = new Tuple<int, int>(x + j, y + i);
                                if(coord.Item1 > -1 && coord.Item1 < lines[0].Length && coord.Item2 > -1 && coord.Item2 < lines.Count()) 
                                {
                                    char item = schematic[coord.Item1, coord.Item2];
                                    if(Regex.IsMatch(Convert.ToString(item), "[0-9]"))
                                    {
                                        string tmp = GetFullNumber(lines[coord.Item2], coord.Item1);
                                        if (!nums.Contains(tmp))
                                        {
                                            nums.Add(tmp);
                                            // sum += Convert.ToInt32(tmp)
                                        }
                                    }
                                }
                            }
                        }
                        if(nums.Count() > 1) 
                        {
                            int tmp = 1;
                            for(int ctr = 0; ctr < nums.Count(); ctr++)
                            {
                                tmp *= Convert.ToInt32(nums[ctr]);
                            }
                            sum += tmp;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }

        static string GetFullNumber(string line, int startIndex)
        {
            if(startIndex == -1 || line == "") { return ""; }
            if (!(Regex.IsMatch(Convert.ToString(line[startIndex]), "[0-9]"))) { return ""; }

            string left = "";
            try
            {
                left = line.Substring(0, startIndex);
            }
            catch (ArgumentOutOfRangeException) { }
            string right = line.Substring(startIndex + 1);

            return GetFullNumber(left, left.Length - 1) + line[startIndex] + GetFullNumber(right, 0);
        }
    }
}
