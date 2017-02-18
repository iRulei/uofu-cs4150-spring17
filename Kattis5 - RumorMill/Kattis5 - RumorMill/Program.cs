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

            // file reading
            int sCount = -1;
            int fCount = -1;
            int rCount = -1;
            int lc = 0;
            //string line;
            //while ((line = Console.ReadLine()) != null)
            foreach (string line in File.ReadAllLines("k5test2.txt"))
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
                    og.dayTold.Add(line, -1);
                }
                else if ((sCount + 1) < lc && lc < (sCount + fCount + 2))
                {
                    string[] pair = line.Split(' ');
                    og.friendsOf[pair[0]].Add(pair[1]);
                    og.friendsOf[pair[1]].Add(pair[0]);
                }
                else if ((sCount + fCount + 2) < lc)
                {
                    og.Reset();
                    og.Spread(line);
                }
                lc++;
            }
            Console.Read();
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

        public void Spread(string start)
        {
            dayTold[start] = 0;
            fQ.Enqueue(start);
            while (fQ.Count > 0)
            {
                string kid = fQ.Dequeue();
                foreach(string friend in friendsOf[kid])
                {
                    if(dayTold[friend] == -1)
                    {
                        fQ.Enqueue(friend);
                        dayTold[friend] = dayTold[kid] + 1;
                        toldBy[friend] = kid;
                    }
                }
            }

            List<string> soLonely = new List<string>();
            Dictionary<int, List<string>> d2k = new Dictionary<int, List<string>>();
            for(int i = 0; i <= dayTold.Values.Max(); i++)
                d2k.Add(i, new List<string>());
            foreach(KeyValuePair<string, int> kvp in dayTold)
                if (kvp.Value >= 0)
                    d2k[kvp.Value].Add(kvp.Key);
                else
                    soLonely.Add(kvp.Key);

            StringBuilder report = new StringBuilder();
            foreach(List<string> l in d2k.Values)
            {
                l.Sort();
                foreach(string s in l)
                    report.Append(s + " ");
            }
            soLonely.Sort();
            foreach(string s in soLonely)
                report.Append(s + " ");

            report.Remove(report.Length - 1, 1);
            Console.Out.WriteLine(report.ToString());
        }

        public void Reset()
        {
            foreach(string s in friendsOf.Keys)
            {
                toldBy[s] = "";
                dayTold[s] = -1;
            }
            fQ.Clear();
        }
    }
}
