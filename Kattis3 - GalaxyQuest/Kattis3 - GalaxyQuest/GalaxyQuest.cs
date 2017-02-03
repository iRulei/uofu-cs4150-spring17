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
            List<Star> universe = new List<Star>();
            int lc = 0;
            int d = 0;
            foreach (string line in File.ReadLines("k3test1.txt"))
            //string line = "";
            //while ((line = Console.ReadLine()) != null)
            {
                if (lc == 0)
                {
                    string[] info = line.Split(' ');
                    d = Int32.Parse(info[0]);
                    lc++;
                    continue;
                }
                string[] coords = line.Split(' ');
                universe.Add(new Star(Int32.Parse(coords[0]), Int32.Parse(coords[1]), d));
                lc++;
            }

            // do the majority element algorithm
            List<Star> candidates = new List<Star>();

            foreach (Star s in universe)
            {
                if (universe[i].Equals(universe[i+1]))
                {
                    
                }
            }

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
