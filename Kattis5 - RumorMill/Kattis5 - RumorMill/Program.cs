using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattis5
{
    class Program
    {
        static void Main(string[] args)
        {
            // graph
            RumorMill og = new RumorMill();
            RumorMill g = new RumorMill();

            // file reading
            int sCount = -1;
            int fCount = -1;
            int rCount = -1;
            int lc = 0;
            //string line;
            //while ((line = Console.ReadLine()) != null)
            foreach (string line in File.ReadAllLines("k5test1.txt"))
            {
                // extract student, friendship, and report counts (continue loop when each is found)
                if (lc == 0)
                {
                    sCount = Int32.Parse(line);
                    lc++;
                    continue;
                }
                else if (lc == (sCount + 1))
                {
                    fCount = Int32.Parse(line);
                    lc++;
                    continue;
                }
                else if (lc == (sCount + fCount + 2))
                {
                    rCount = Int32.Parse(line);
                    lc++;
                    continue;
                }

                // load that information into a graph
                if (0 < lc && lc < (sCount + 1))
                {
                    og.friendsOf.Add(line, new List<string>());
                    og.toldBy.Add(line, null);
                    og.dayTold.Add(line, Int32.MaxValue);
                }
                else if ((sCount + 1) < lc && lc < (sCount + fCount + 2))
                {
                    string[] pair = line.Split(' ');
                    og.friendsOf[pair[0]].Add(pair[1]);
                }
                else if ((sCount + fCount + 2) < lc)
                {
                    g = og;
                    g.Spread(line);
                }
            }
        }
    }

    class RumorMill
    {
        public Dictionary<string, List<string>> friendsOf;
        public Dictionary<string, string> toldBy;
        public Dictionary<string, int> dayTold;
        public Queue<string> fQ; 

        public RumorMill()
        {
            toldBy = new Dictionary<string, string>();
            dayTold = new Dictionary<string, int>();
            friendsOf = new Dictionary<string, List<string>>();
            fQ = new Queue<string>();
        }

        public Spread(string start)
        {
            int day = 0;

        }
    }
}
