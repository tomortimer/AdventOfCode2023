using System;
using System.Linq;
using System.Runtime.InteropServices;
using MorteTools;
namespace Day_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");

            int sum = 0;
            foreach (string line in lines)
            {
                string pattern = line.Split(' ')[0];
                List<int> groups = fp.GetListInt(line.Split(' ')[1], ',');
                int tmp = GetPossiblePatterns(pattern, groups);
                Console.WriteLine(line+ " has " +tmp+ " arrangements");
                sum += tmp;
            }
            Console.WriteLine("Part One: "+sum);
        }

        static int GetPossiblePatterns(string pattern, List<int> groups) 
        {
            int count = 0;
            
            //base cases for empty groups lists or empty pattern
            if(groups.Count() == 0)
            {
                //should be no broken(#) by now
                if (!pattern.Contains('#')) { return 1; }
                else { return 0; }
            }
            if(pattern.Length == 0) {  return 0; }

            char currentChar = pattern[0];

            //move until get to hash
            if(currentChar == '.')
            {
                count = Dot(pattern, groups.Clone());
            }else if(currentChar == '#') 
            {
                count = Hash(pattern, groups.Clone());
            }
            else if(currentChar == '?')
            {
                count = Hash(pattern, groups.Clone()) + Dot(pattern, groups);
            }

            return count;
        }

        static int Dot(string pattern, List<int> groups)
        {
            return GetPossiblePatterns(pattern.Substring(1), groups);
        }

        static int Hash(string pattern, List<int> groups)
        {
            int currentGroup = groups[0];
            string testGroup;
            try
            {
                testGroup = pattern.Remove(currentGroup);
            }catch(ArgumentOutOfRangeException e)
            {
                return 0;
            }
            
            //assume broken springs
            testGroup = testGroup.Replace('?', '#');
            //now validate - break out if doesn't work
            if (testGroup != ConstructString(currentGroup, '#')) { return 0; }

            //now see if end reached
            if (pattern.Length == currentGroup)
            {
                if (groups.Count() == 1) { 
                    return 1; } else { 
                    return 0; }
            }

            //check next char can be a separator '.' 
            if (pattern[currentGroup] == '.' || pattern[currentGroup] == '?')
            {
                groups.RemoveAt(0);
                return GetPossiblePatterns(pattern.Substring(currentGroup+1), groups);
            }

            //otherwise cry
            return 0;
        }

        static string ConstructString(int num, char inp)
        {
            string ret = "";
            for(int i = 0; i < num; i++)
            {
                ret += inp.ToString();
            }
            return ret;
        }
    }
}
