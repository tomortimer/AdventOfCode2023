using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day_5
{
    internal class Map
    {
        List<MapRow> rows;
        public Map() 
        {
            rows = new List<MapRow>();
        }

        public void AddRow(string line)
        {
            string[] parts = line.Split(' ');
            MapRow tmp = new MapRow(Convert.ToInt64(parts[0]), Convert.ToInt64(parts[1]), Convert.ToInt64(parts[2]));
            rows.Add(tmp);
        }

        public long Transform(long input)
        {
            long ret = -1;
            for(int i = 0; i < rows.Count; i++)
            {
                if (rows[i].IsInRange(input)) { ret = rows[i].Transform(input); i = rows.Count(); }
            }
            if(ret == -1) { ret = input; }
            return ret;
        }
    }
}
