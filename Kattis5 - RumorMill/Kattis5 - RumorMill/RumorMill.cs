using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumorMill
{
    class RumorMill
    {
        static void Main(string[] args)
        {
            // graph


            // file reading
            int sCount = -1;
            int fCount = -1;
            int rCount = -1;
            int lc = 0;
            string[] lArray;
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

                }
                else if ((sCount + 1) < lc && lc < (sCount + fCount + 2))
                {

                }
                else if ((sCount + fCount + 2) < lc)
                {

                }
            }
        }
    }

    class ClassGraph
    {
        Dictionary<string, string> prev;
        Dictionary<string, bool> visited;

        public ClassGraph()
        {
            prev = new Dictionary<string, string>();
            visited = new Dictionary<string, bool>();
        }

        public void ResetGraph()
        {
            prev = new Dictionary<string, string>();
            visited = new Dictionary<string, bool>();
        }
    }
}
