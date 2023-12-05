using System;
using MorteTools;
using System.IO;

namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            StreamReader reader = new StreamReader("input.txt");
            List<string> seedsInp = new List<string>(reader.ReadLine().Substring(7).Split(' '));
            List<long> seeds = new List<long>();
            for(int i = 0; i < seedsInp.Count(); i+=2) 
            {
                int seedRange = Convert.ToInt32(seedsInp[i + 1]);
                for(int j = 0; j < seedRange; j++)
                {
                    seeds.Add(Convert.ToInt64(seedsInp[i]) + j);
                } 
            }

            //now read in first table seeds to soil map
            reader.ReadLine();
            reader.ReadLine();
            string line = reader.ReadLine();
            Map SeedsToSoil = new Map();
            while(line != null && line != "") 
            { 
                SeedsToSoil.AddRow(line);
                line = reader.ReadLine();
            }

            //read in next map
            reader.ReadLine();
            line = reader.ReadLine();
            Map SoilToFert = new Map();
            while (line != null && line != "")
            {
                SoilToFert.AddRow(line);
                line = reader.ReadLine();
            }

            //read in next map
            reader.ReadLine();
            line = reader.ReadLine();
            Map FertToWater = new Map();
            while (line != null && line != "")
            {
                FertToWater.AddRow(line);
                line = reader.ReadLine();
            }

            //read in next map
            reader.ReadLine();
            line = reader.ReadLine();
            Map WaterToLight = new Map();
            while (line != null && line != "")
            {
                WaterToLight.AddRow(line);
                line = reader.ReadLine();
            }

            //read in next map
            reader.ReadLine();
            line = reader.ReadLine();
            Map LightToTemp = new Map();
            while (line != null && line != "")
            {
                LightToTemp.AddRow(line);
                line = reader.ReadLine();
            }

            //read in next map
            reader.ReadLine();
            line = reader.ReadLine();
            Map TempToHumid = new Map();
            while (line != null && line != "")
            {
                TempToHumid.AddRow(line);
                line = reader.ReadLine();
            }

            //read in last map
            reader.ReadLine();
            line = reader.ReadLine();
            Map HumidToLoc = new Map();
            while (line != null && line != "")
            {
                HumidToLoc.AddRow(line);
                line = reader.ReadLine();
            }

            reader.Close();

            //now transform all seeds
            long lowest = -1;
            for(int x = 0; x < seeds.Count(); x++) 
            {
                seeds[x] = SeedsToSoil.Transform(seeds[x]);
                seeds[x] = SoilToFert.Transform(seeds[x]);
                seeds[x] = FertToWater.Transform(seeds[x]);
                seeds[x] = WaterToLight.Transform(seeds[x]);
                seeds[x] = LightToTemp.Transform(seeds[x]);
                seeds[x] = TempToHumid.Transform(seeds[x]);
                seeds[x] = HumidToLoc.Transform(seeds[x]);
                if (seeds[x] < lowest || lowest == -1) { lowest = seeds[x]; }
                Console.WriteLine(seeds[x]);
            }
            Console.WriteLine("Lowest: " + lowest);
        }
    }
}