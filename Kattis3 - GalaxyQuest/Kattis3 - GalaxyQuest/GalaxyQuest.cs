﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyQuest
{
    class GalaxyQuest
    {
        static void Main(string[] args)
        {
            // get all the stars
            Star[] universe = new Star[0];
            int lc = 0;
            int d = 0;
            int sc = 0;
            foreach (string line in File.ReadLines("k3test1.txt"))
            //string line = "";
            //while ((line = Console.ReadLine()) != null)
            {
                if (lc == 0)
                {
                    string[] info = line.Split(' ');
                    d = Int32.Parse(info[0]);
                    sc = Int32.Parse(info[1]);
                    universe = new Star[sc];
                    lc++;
                    continue;
                }
                string[] coords = line.Split(' ');
                universe[lc - 1] = new Star(Int32.Parse(coords[0]), Int32.Parse(coords[1]), d);
                lc++;
            }

            // do the majority element algorithm
            Star[] candidates = new Star[sc];

            for

            Console.Out.WriteLine();
            Console.Read();
        }

        public class Star
        {
            private long x;
            private long y;
            private long d;

            public Star(long inX, long inY, long inD)
            {
                x = inX;
                y = inY;
                d = inD;
            }

            public override bool Equals(object obj)
            {
                Star other = (Star)obj;
                return ((Math.Pow(other.x - this.x, 2) + Math.Pow(other.y - this.y, 2)) <= Math.Pow(d, 2));
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public void PrintCoords()
            {
                Console.Out.WriteLine("(" + x + ", " + y + ")");
            }
        }
    }
}
