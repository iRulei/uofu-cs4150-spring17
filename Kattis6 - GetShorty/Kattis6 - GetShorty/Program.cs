using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetShorty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dungeon> dungeons = new List<Dungeon>();

            //string input = "";
            //while ((input = Console.ReadLine()) != null)

            // process input
            foreach(string input in File.ReadLines("k6test1.txt"))
            {
                string[] line = input.Split();
                if (line.Count() == 2)
                    dungeons.Add(new Dungeon(Int32.Parse(line[0]), Int32.Parse(line[1])));                    
                else
                    dungeons.Last().AddHall(line[0], line[1], float.Parse(line[2]));
            }

            // process dungeons

        }
    }

    public class Dungeon
    {
        public Dictionary<string, List<Hall>> halls;
        public Dictionary<string, string> prev;
        public Dictionary<string, float> factor;
        //public ;  // YOU NEED TO IMPLEMENT A BINARY-HEAP-BASED PQ

        public Dungeon(int _rc, int _hc)
        {
            halls = new Dictionary<string, List<Hall>>();
        }

        public void Escape()
        {

        }

        public void AddHall(string _r1, string _r2, float _fac)
        {
            halls[_r1].Add(new Hall(_r2, _fac));
            halls[_r2].Add(new Hall(_r1, _fac));
        }

        public class Hall
        {
            public string end;
            public float  fac;

            public Hall(string _end, float _fac)
            {
                end = _end;
                fac = _fac;
            }
        }

        public class DungeonQueue
        {

        }
    }
}
