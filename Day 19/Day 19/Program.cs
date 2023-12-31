﻿using System.Net;

namespace Day_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MorteTools.List<string> lines = new MorteTools.FileParser().GetLinesFromTxt("input.txt");
            Dictionary<string, Workflow> sorter = new Dictionary<string, Workflow>();
            Dictionary<string, Workflow> accepters = new Dictionary<string, Workflow>();
            
            int i = 0;
            while (lines[i] != "") 
            {
                string ID = lines[i].Split('{')[0];
                string workflow = lines[i].Split('{')[1].Trim('}');
                Workflow tmp = new Workflow(workflow);
                sorter.Add(ID, tmp);
                if (workflow.Contains("A")) { accepters.Add(ID, tmp); }
                i++;
            }

            int[] startLower = { 1, 1, 1, 1};
            int[] startUpper = { 4000, 4000, 4000, 4000 };

            //enter w/ bounds
            //adjust each bound, try every path, passing down bounds
            // once accept reached, return bounds
            // once reject reached, return null
            //have return object be a list so as to collate bounds
            // sum possible entries
            //compare upper and lower and expand primary bound unless secondary is not contained or partially in primary


            //Part One Stuff:
            /*i++;
            List<Part> parts = new List<Part>();
            while (i < lines.Count())
            {
                string part = lines[i].Trim(new char[] { '{', '}' });
                parts.Add(new Part(part));
                i++;
            }

            List<Part> acceptedParts = new List<Part>();
            foreach( Part part in parts )
            {
                do
                {
                    part.workflow = sorter[part.workflow].GetNextState(part);
                } while (!(part.workflow == "A" || part.workflow == "R"));

                if(part.workflow == "A")
                {
                    acceptedParts.Add(part);
                    Console.WriteLine("Accepted: " + part.GetScore());
                }
            }
            long sum = 0;
            foreach( Part part in acceptedParts )
            {
                sum += part.GetScore();
            }
            Console.WriteLine(sum);*/
        }

        static int[] FindRange(int[] lowerBound, int[] upperBound, string workflow) 
        {
        }
    }
}
