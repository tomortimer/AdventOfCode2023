using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using MorteTools;
namespace Day_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            List<string> lines = fp.GetLinesFromTxt("input.txt");
            Memoiser memoMachine = new Memoiser();

            Func<Tuple<string,string>, int> GetPatterns = GetPossiblePatterns;
            GetPatterns = memoMachine.Memoise(GetPatterns);
            Func<Tuple<string,string>, int> HashCase = Hash;
            HashCase = memoMachine.Memoise(HashCase);
            Func<Tuple<string,string>, int> DotCase = Dot;
            DotCase = memoMachine.Memoise(DotCase);

            int sum = 0;
            foreach (string line in lines)
            {
                string pattern = line.Split(' ')[0];
                string groups = line.Split(' ')[1];
                string newPattern = "";
                string newGroups = "";
                for(int i = 0; i < 5; i++)
                {
                    newPattern += pattern;
                    if(i != 4) { newPattern += "?"; }
                    newGroups += groups;
                    if(i != 4) { newGroups += ","; }
                }
                int tmp = GetPatterns(new Tuple<string,string>(newPattern, newGroups));
                Console.WriteLine(line+ " has " +tmp+ " arrangements");
                sum += tmp;
            }
            Console.WriteLine("Part One: "+sum);
        }

        static int GetPossiblePatterns(Tuple<string,string> inp) 
        {
            int count = 0;
            //reconstruct list and pattern
            string pattern = inp.Item1;
            List<int> groups = ParseInts(inp.Item2);
            
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
                count = Dot(inp);
            }else if(currentChar == '#') 
            {
                count = Hash(inp);
            }
            else if(currentChar == '?')
            {
                count = Hash(inp) + Dot(inp);
            }

            return count;
        }

        static int Dot(Tuple<string,string> inp)
        {
            string pattern = inp.Item1.Substring(1);
            return GetPossiblePatterns(new Tuple<string,string>(pattern, inp.Item2));
        }

        static int Hash(Tuple<string,string> inp)
        {
            //reconstruct list and pattern
            string pattern = inp.Item1;
            List<int> groups = ParseInts(inp.Item2);

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
                pattern = pattern.Substring(currentGroup + 1);
                return GetPossiblePatterns(new Tuple<string, string>(pattern, groups.ToString()));
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

        static List<int> ParseInts(string input)
        {
            string[] parts = input.Split(',');
            List<int> ret = new List<int>();
            if (parts[0] != "")
            {
                foreach (string part in parts)
                {
                    ret.Add(int.Parse(part));
                }
            }
            return ret;
        }
    }
}
