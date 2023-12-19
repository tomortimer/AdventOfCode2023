﻿using System.Net.Http.Headers;
using System.Numerics;
using System.Security.AccessControl;

namespace Day_16
{
    enum Directions
    {
        Right, // 0
        Down, // 1
        Left, // 2
        Up // 3
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MorteTools.List<string> lines = new MorteTools.FileParser().GetLinesFromTxt("input.txt");
            int width = lines[0].Length;
            int height = lines.Count();
            char[,] grid = new char[width, height];
            for(int y = 0; y < height;  y++)
            {
                for(int x = 0; x < width; x++)
                {
                    grid[x, y] = lines[y][x];
                }
            }
            //map vector to direction
            List<Beam> beams = new List<Beam> { new Beam(new Vector2(0,0), (int)Directions.Right) };
            Dictionary<int, Vector2> transformations = new Dictionary<int, Vector2>
            {
                { (int)Directions.Right, new Vector2(1, 0) },
                { (int)Directions.Down, new Vector2(0, 1) },
                { (int)Directions.Left, new Vector2(-1, 0) },
                { (int)Directions.Up, new Vector2(0, -1) }
            };
            List<Tuple<int,int>> visited = new List<Tuple<int,int>>();
            while(beams.Count() > 0)
            {
                List<Beam> newBeams = new List<Beam>();
                for (int i = 0; i < beams.Count(); i++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>((int)beams[i].pos.X, (int)beams[i].pos.Y);
                    if (!visited.Contains(pos)) { visited.Add(pos); }
                    beams[i].pos += transformations[beams[i].direction];
                    if (beams[i].pos.X < 0 || beams[i].pos.X >= width || beams[i].pos.Y < 0 || beams[i].pos.Y >= height) { beams.RemoveAt(i); }
                    else
                    {
                        switch(grid[(int)beams[i].pos.X, (int)beams[i].pos.Y])
                        {
                            case '/':
                                switch (beams[i].direction)
                                {
                                    case (int)Directions.Right: beams[i].direction = (int)Directions.Up; break;
                                    case (int)Directions.Down: beams[i].direction = (int)Directions.Left; break;
                                    case (int)Directions.Left: beams[i].direction = (int)Directions.Down; break;
                                    case (int)Directions.Up: beams[i].direction = (int)Directions.Right; break;
                                }
                                break;
                            case '\\':
                                switch (beams[i].direction)
                                {
                                    case (int)Directions.Right: beams[i].direction = (int)Directions.Down; break;
                                    case (int)Directions.Down: beams[i].direction = (int)Directions.Right; break;
                                    case (int)Directions.Left: beams[i].direction = (int)Directions.Up; break;
                                    case (int)Directions.Up: beams[i].direction = (int)Directions.Left; break;
                                }
                                break;
                            case '-':
                                if (beams[i].direction == (int)Directions.Up || beams[i].direction == (int)Directions.Down)
                                {
                                    beams[i].direction = (int)Directions.Left;
                                    newBeams.Add(new Beam(new Vector2(beams[i].pos.X, beams[i].pos.Y), (int)Directions.Right));
                                }
                                break;
                            case '|':
                                if (beams[i].direction == (int)Directions.Right || beams[i].direction == (int)Directions.Left)
                                {
                                    beams[i].direction = (int)Directions.Up;
                                    newBeams.Add(new Beam(new Vector2(beams[i].pos.X, beams[i].pos.Y), (int)Directions.Down));
                                }
                                break;
                        }
                    }
                }
                foreach(Beam beam in newBeams)
                {
                    beams.Add(beam);
                }
            }
            Console.WriteLine(visited.Count());
        }
    }
}
