using System;
using MorteTools;

namespace Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            int sum = 0;
            foreach(string line in lines)
            {
                string[] arr = line.Split(' ');
                List<int> lineNums = new List<int>();
                for(int i = 0; i < arr.Length; i++)
                {
                    lineNums.Add(int.Parse(arr[i]));
                }
                Sequence tmp = new Sequence(lineNums);
                sum += tmp.ExtrapolateBackwards();
            }
            Console.WriteLine(sum);
        }
    }
}
