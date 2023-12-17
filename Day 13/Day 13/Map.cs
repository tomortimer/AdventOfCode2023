using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //default return is -1
        public int FindXAxisReflection()
        {
            int ret = -1;
            for(int y = 0; y < height; y++)
            {
                int columnMatchCtr = 0;
                //go across all columns
                for(int x = 0; x < width; x++)
                {
                    int sampleLength = y;
                    if(sampleLength > height - y) { sampleLength = height - y; }
                    string column = ConstructColumn(x);
                    string upToLine = column.Substring(y-sampleLength, sampleLength);
                    string afterLine = Reverse(column.Substring(y, sampleLength));
                    if(upToLine == afterLine && y != 0) { columnMatchCtr++; }
                    else { x = width; }
                }
                if (columnMatchCtr == width) { ret = y; y = height; }
            }
            return ret;
        }
        //default ret as -1
        public int FindYAxisReflection()
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
                    if(upToLine == afterLine && x != 0) {  rowMatchCtr++; }
                    else { y = height; }
                }
                if(rowMatchCtr == height) { ret = x; x = width; }
            }
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
