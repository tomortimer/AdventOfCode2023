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
            // first long is start, second is range
            List<Tuple<long, long>> seedPairs = new List<Tuple<long, long>>();
            for(int i = 0; i < seedsInp.Count(); i+=2) 
            {
                seedPairs.Add(new Tuple<long, long>(Convert.ToInt64(seedsInp[i]), Convert.ToInt64(seedsInp[i + 1])));
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

            /*for(int x = 0; x < seeds.Count(); x++) 
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
            }*/
            bool found = false;
            
            long originalLowest = -1;
            while (!found)
            {
                originalLowest++;
                long num = originalLowest;
                num = HumidToLoc.ReverseTransform(num);
                num = TempToHumid.ReverseTransform(num);
                num = LightToTemp.ReverseTransform(num);
                num = WaterToLight.ReverseTransform(num);
                num = FertToWater.ReverseTransform(num);
                num = SoilToFert.ReverseTransform(num);
                num = SeedsToSoil.ReverseTransform(num);

                for(int x = 0; x < seedPairs.Count(); x++)
                {
                    if (seedPairs[x].Item1 <= num && num < (seedPairs[x].Item1 + seedPairs[x].Item2)) 
                    { 
                        found = true; 
                        x = seedPairs.Count(); 
                    }
                }
            }
            Console.WriteLine("Lowest: " + originalLowest);
        }
    }
}