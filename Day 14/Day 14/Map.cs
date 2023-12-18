using System;
using MorteTools;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
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
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    map[x, y] = inp[y][x];
                }
            }
        }
        public int CalcScore()
        {
            int score = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y] == 'O') { score += (height - y); }
                }
            }
            return score;
        }

        public void RollAllNorth()
        {
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (map[x, y] == 'O') { RollRockNorth(x, y); }
                }
            }
        }

        private void RollRockNorth(int x, int y)
        {
            while(y > 0 && map[x, y - 1] == '.')
            {
                map[x, y] = '.';
                y--;
                map[x, y] = 'O';
            }
        }
        public void RollAllWest()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y] == 'O') { RollRockWest(x, y); }
                }
            }
        }

        private void RollRockWest(int x, int y)
        {
            while (x > 0 && map[x - 1, y] == '.')
            {
                map[x, y] = '.';
                x--;
                map[x, y] = 'O';
            }
        }

        public void RollAllSouth()
        {
            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y] == 'O') { RollRockSouth(x, y); }
                }
            }
        }

        private void RollRockSouth(int x, int y)
        {
            while (y < height-1 && map[x, y +1] == '.')
            {
                map[x, y] = '.';
                y++;
                map[x, y] = 'O';
            }
        }

        public void RollAllEast()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = width-1; x >= 0; x--)
                {
                    if (map[x, y] == 'O') { RollRockEast(x, y); }
                }
            }
        }

        private void RollRockEast(int x, int y)
        {
            while (x < width-1 && map[x+1, y] == '.')
            {
                map[x, y] = '.';
                x++;
                map[x, y] = 'O';
            }
        }

        public void SpinCycle()
        {
            RollAllNorth();
            RollAllWest();
            RollAllSouth();
            RollAllEast();
        }

        public void PrintGrid()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            string ret = "";
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    ret += map[x, y];
                }
            }
            return ret;
        }
    }
}
