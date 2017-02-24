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

            //string line = "";
            //while ((line = Console.ReadLine()) != null)
            string[] lines = File.ReadAllLines("k6test1.txt");
            for(int i = 0; i < lines.Count(); i++)
            {
                string[] thisLine = lines[i].Split();
                if (thisLine.Count() == 2)
                    dungeons.Add(new Dungeon(Int32.Parse(thisLine[0]), Int32.Parse(thisLine[1])));                    
                else
                {
                    dungeons.Last.rooms.
                }
            }

            // process each test case

        }
    }

    public class Dungeon
    {
        public Dictionary<string, List<string>> halls;

        public Dungeon(int _rc, int _hc)
        {
            halls = new Dictionary<string, List<string>>();
        }

        public class Hall
        {
            public string end;
            public int    wgt;

            public Hall(string _end, int _wgt)
            {
                end = _end;
                wgt = _wgt;
            }
        }
    }
}
