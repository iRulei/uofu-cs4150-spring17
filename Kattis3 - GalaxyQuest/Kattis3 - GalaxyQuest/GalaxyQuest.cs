using System;
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
            foreach (string line in File.ReadLines("k3test8.txt"))
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

            /*
            int mDex = 0;
            int mCount = 1;

            for (int i = 1; i < sc; i++)
            {
                if (universe[mDex].Equals(universe[i]))
                    mCount++;
                else
                    mCount--;

                if (mCount == 0)
                {
                    mDex = i;
                    mCount = 1;
                }
            }

            Star cand = universe[mDex];
            int majNum = 0;
            for (int i = 0; i < sc; i++)
            {
                if (universe[i].Equals(cand))
                {
                    majNum++;
                }
            }

            if (majNum > sc / 2)
                Console.Out.Write(majNum);
            else
                Console.Out.Write("NO");
            */

            // keep a copy of the original universe
            List<Star> OU = new List<Star>(universe);

            // find the majority element candidate
            bool hasCand = true;
            bool b = true;
            int matchCount = 0;
            List<Star> candidates = new List<Star>();
            bool foundCands = false;
            while(!foundCands)
            {
                candidates = new List<Star>();

                for (int i = 0; i < universe.Length; i+=2)
                {
                    if(i == universe.Length - 1)
                    {
                        break;
                    }

                    if(universe[i].Equals(universe[i+1]))
                    {
                        candidates.Add(universe[i]);
                    }
                    
                }

                if (candidates.Count == 0)
                {
                    hasCand = false;
                    break;
                }
                universe = candidates.ToArray();
                
                if (candidates.Count == 1)
                    foundCands = true;
            }

            if (hasCand)
            {
                // assuming there is a candidate, 
                // determine whether it is a majority element
                Star cand = candidates.First<Star>();
                foreach(Star s in OU)
                {
                    if (cand.Equals(s))
                    {
                        matchCount++;
                    }
                }

                if (matchCount >= sc/2)
                {
                    hasCand = true;
                }
                else
                {
                    hasCand = false;
                }
            }
            else
            {
                Console.Write("NO");
                b = false;
            }

            if (hasCand)
            {
                Console.Out.Write(matchCount);
            }
            else if (b)
            {
                Console.Out.Write("NO");
            }

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

            public string Coords()
            {
                return "(" + x + ", " + y + ")";
            }
        }
    }
}
