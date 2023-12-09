using System;
using MorteTools;
namespace Day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("AAA", 52);
            dict.Add("ZZZ", 1);
            Console.WriteLine(dict["AAA"]);
            Console.WriteLine(dict["ZZZ"]);
        }
    }
}
