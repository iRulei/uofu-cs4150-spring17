using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSink
{
    class AutoSink
    {
        static void Main(string[] args)
        {
            int cityCount = -1;
            int hwCount = -1;
            int tripCount = -1;
            int lc = 0;

            string line;
            while ((line = Console.ReadLine()) != null)
            {
                // extract city, highway, and trip counts (continue loop when each is found)
                if (lc == 0)
                {
                    cityCount = Int32.Parse(line);
                    lc++;
                    continue;
                }
                else if (lc == (cityCount + 1))
                {
                    hwCount = Int32.Parse(line);
                    lc++;
                    continue;
                }
                else if (lc == (cityCount + hwCount + 2))
                {
                    tripCount = Int32.Parse(line);
                    lc++;
                    continue;
                }

                // process city, highway, and trip information
                if (0 < lc && lc < (cityCount + 1))
                {

                }
                else if ((cityCount + 1) < lc && lc < (cityCount + hwCount + 2))
                {

                } 
                else if ((cityCount + hwCount + 2) < lc)
                {

                }
            }
        }
    }

    class CityMap
    {
        public void clearCosts() { }
    }

    class CityNode
    {
        public string name;
        public int toll;
        public int routeCost;
    }
}
