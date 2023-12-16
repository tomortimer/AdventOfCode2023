using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
