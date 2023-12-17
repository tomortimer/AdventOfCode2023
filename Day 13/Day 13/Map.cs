using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
    internal class Map
    {
        char[,] map;
        int width;
        int height;
        public Map(List<string> inp)
        {
            width = inp[0].Length;
            height = inp.Count();
            map = new char[width, height];
            for(int y = 0; y < inp.Count(); y++)
            {
                for(int x = 0; x < inp[y].Length; x++)
                {
                    map[x, y] = inp[y][x];
                }
            }
        }

        public int FindXAxisReflectionPartOne()
        {
            int ret = -1;
            for (int y = 0; y < height; y++)
            {
                int columnMatchCtr = 0;
                //go across all columns
                for (int x = 0; x < width; x++)
                {
                    int sampleLength = y;
                    if (sampleLength > height - y) { sampleLength = height - y; }
                    string column = ConstructColumn(x);
                    string upToLine = column.Substring(y - sampleLength, sampleLength);
                    string afterLine = Reverse(column.Substring(y, sampleLength));
                    if (upToLine == afterLine && y != 0) { columnMatchCtr++; }
                    else { x = width; }
                }
                if (columnMatchCtr == width) { ret = y; y = height; }
            }
            return ret;
        }
        //default ret as -1
        public int FindYAxisReflectionPartOne()
        {
            int ret = -1;
            for (int x = 0; x < width; x++)
            {
                int rowMatchCtr = 0;
                //go across all rows
                for (int y = 0; y < height; y++)
                {
                    int sampleLength = x;
                    if (sampleLength > width - x) { sampleLength = width - x; }
                    string row = ConstructRow(y);
                    string upToLine = row.Substring(x - sampleLength, sampleLength);
                    string afterLine = Reverse(row.Substring(x, sampleLength));
                    if (upToLine == afterLine && x != 0) { rowMatchCtr++; }
                    else { y = height; }
                }
                if (rowMatchCtr == height) { ret = x; x = width; }
            }
            return ret;
        }

        //default return is -1
        public int FindXAxisReflection()
        {
            int ret = -1;
            for(int y = 0; y < height; y++)
            {
                int columnMatchCtr = 0;
                int sampleLength = y;
                if (sampleLength > height - y) { sampleLength = height - y; }
                //calculate necessary matching chars
                int necessaryMatches = sampleLength * 2 * width;
                Tuple<int, int> bizarreCharPos = new Tuple<int, int>(-1,-1);
                int matchingChars = 0;
                //go across all columns
                for (int x = 0; x < width; x++)
                {
                    string column = ConstructColumn(x);
                    string upToLine = column.Substring(y-sampleLength, sampleLength);
                    string afterLine = Reverse(column.Substring(y, sampleLength));
                    if(upToLine == afterLine && y != 0) { columnMatchCtr++; matchingChars += sampleLength * 2; }
                    else
                    {
                        Tuple<int, int> tmp = CountMatchingCharsAndFindPos(upToLine, afterLine);
                        matchingChars += tmp.Item1;
                        int yCoord = y - sampleLength + tmp.Item2;
                        bizarreCharPos = new Tuple<int, int>(x, yCoord);
                    }
                }
                if (columnMatchCtr == width) { Console.WriteLine("Horizontal Symmetry at: " + y); }
                //is one off attempt symmetry with switch
                if(matchingChars + 2 == necessaryMatches) 
                {
                    //invert symbol
                    if (map[bizarreCharPos.Item1, bizarreCharPos.Item2] == '#') { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '.'; }
                    else { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '#'; }
                    //validate symmetry
                    bool valid = ValidateXSymmetry(y);
                    if(valid) { ret = y; Console.WriteLine("Horizontal Alt symmetry found at: " + y+ " Char swapped at X: "+bizarreCharPos.Item1 +" Y: "+bizarreCharPos.Item2); }
                    //reverse change
                    if (map[bizarreCharPos.Item1, bizarreCharPos.Item2] == '#') { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '.'; }
                    else { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '#'; }
                }
            }
            return ret;
        }

        public bool ValidateXSymmetry(int y)
        {
            int columnMatchCtr = 0;
            int sampleLength = y;
            if (sampleLength > height - y) { sampleLength = height - y; }
            for (int x = 0; x < width; x++)
            {
                string column = ConstructColumn(x);
                string upToLine = column.Substring(y - sampleLength, sampleLength);
                string afterLine = Reverse(column.Substring(y, sampleLength));
                if (upToLine == afterLine && y != 0) { columnMatchCtr++; }
                else { x = width; }
            }
            bool ret = false;
            if (columnMatchCtr == width) { ret = true; }
            return ret;
        }

        //default ret as -1
        public int FindYAxisReflection()
        {
            int ret = -1;
            for (int x = 0; x < width; x++)
            {
                int sampleLength = x;
                if (sampleLength > width - x) { sampleLength = width - x; }
                int rowMatchCtr = 0;
                //calculate necessary matching chars
                int necessaryMatches = sampleLength * 2 * height;
                Tuple<int, int> bizarreCharPos = new Tuple<int, int>(-1, -1);
                int matchingChars = 0;
                //go across all rows
                for (int y = 0; y < height; y++)
                {
                    string row = ConstructRow(y);
                    string upToLine = row.Substring(x - sampleLength, sampleLength);
                    string afterLine = Reverse(row.Substring(x, sampleLength));
                    if (upToLine == afterLine && x != 0) { rowMatchCtr++; matchingChars += sampleLength * 2; }
                    else
                    {
                        Tuple<int, int> tmp = CountMatchingCharsAndFindPos(upToLine, afterLine);
                        matchingChars += tmp.Item1;
                        int xCoord = x - sampleLength + tmp.Item2;
                        bizarreCharPos = new Tuple<int, int>(xCoord, y);
                    }
                }
                if(rowMatchCtr == height) { 
                    Console.WriteLine("Vertical symmetry at: "+x); }
                //is one off attempt symmetry with switch
                if (matchingChars + 2 == necessaryMatches)
                {
                    //invert symbol
                    if (map[bizarreCharPos.Item1, bizarreCharPos.Item2] == '#') { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '.'; }
                    else { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '#'; }
                    //validate symmetry
                    bool valid = ValidateYSymmetry(x);
                    if (valid) { ret = x; Console.WriteLine("Vertical Alt Symmetry at: " + x + " Char at X: " + bizarreCharPos.Item1 + " Y: " + bizarreCharPos.Item2); }
                    //MAKE SURE TO UNDO CHANGES!!!
                    if (map[bizarreCharPos.Item1, bizarreCharPos.Item2] == '#') { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '.'; }
                    else { map[bizarreCharPos.Item1, bizarreCharPos.Item2] = '#'; }
                }
            }
            return ret;
        }

        public bool ValidateYSymmetry(int x)
        {
            int rowMatchCtr = 0;
            int sampleLength = x;
            if (sampleLength > width - x) { sampleLength = width - x; }
            for (int y = 0; y < height; y++)
            {
                string row = ConstructRow(y);
                string upToLine = row.Substring(x - sampleLength, sampleLength);
                string afterLine = Reverse(row.Substring(x, sampleLength));
                if (upToLine == afterLine && x != 0) { rowMatchCtr++; }
                else { y = height; }
            }
            bool ret = false;
            if (rowMatchCtr == height) { ret = true; }
            return ret;
        }

        public Tuple<int, int> CountMatchingCharsAndFindPos(string firstHalf, string secondHalf) 
        {
            int misMatchIndex = -1;
            int matchingCtr = 0;
            for(int i = 0; i < firstHalf.Length; i++)
            {
                if (firstHalf[i] == secondHalf[i]) {  matchingCtr+=2; }
                else
                {
                    misMatchIndex = i;
                }
            }
            Tuple<int, int> ret = new Tuple<int, int>(matchingCtr, misMatchIndex);
            return ret;
        }

        public string ConstructRow(int y)
        {
            string ret = "";
            for(int x = 0; x < width; x++) { ret += map[x, y]; }
            return ret;
        }
        public string ConstructColumn(int x)
        {
            string ret = "";
            for(int y = 0; y < height; y++) { ret += map[x, y]; }
            return ret;
        }
        public string Reverse(string inp)
        {
            Stack<char> stack = new Stack<char>();
            foreach(char c in inp)
            {
                stack.Push(c);
            }
            string tmp = "";
            while(stack.Count > 0)
            {
                tmp += stack.Pop();
            }
            return tmp;
        }
    }
}
