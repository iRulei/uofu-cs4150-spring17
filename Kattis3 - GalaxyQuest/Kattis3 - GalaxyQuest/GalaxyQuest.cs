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
            string[] lines = File.ReadAllLines("k3test1.txt");

            string[] info = lines[0].Split(' ');
            int d = Int32.Parse(info[0]);
            Star[] universe = new Star[Int32.Parse(info[1])];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] coords = lines[i].Split(' ');
                universe[i] = new Star(Int32.Parse(coords[0]), Int32.Parse(coords[1]), d);
            }

            //string line = Console.ReadLine();
            //while ((line = Console.ReadLine()) != null)
            //{

            //}

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
        }
    }
}
