using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSink
{
    class AutoSink
    {
        static void Main(string[] args)
        {
            Dictionary<CityNode, List<CityNode>> map = new Dictionary<CityNode, List<CityNodse>>();

            int cityCount = -1;
            int hwCount = -1;
            int tripCount = -1;
            int lc = 0;
            string[] lineItems;
            //string line;
            //while ((line = Console.ReadLine()) != null)
            foreach(string line in File.ReadAllLines("k4test1.txt"))
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
                if ((0 < lc) && (lc < (cityCount + 1)))
                {
                    lineItems = line.Split(' ');
                    map.Add(new CityNode(lineItems[0], Int32.Parse(lineItems[1])), new List<CityNode>());
                    lc++;
                    continue;
                }
                else if (((cityCount + 1) < lc) && (lc < (cityCount + hwCount + 2)))
                {
                    lc++;
                    continue;
                }
                else if ((cityCount + hwCount + 2) < lc)
                {
                    lc++;
                    continue;
                }
            }

            Console.Out.WriteLine(cityCount + " " + hwCount + " " + tripCount);
            Console.Read();
        }
    }

    class CityMap
    {

        public CityMap() { }
        public void clearCosts() { }
    }

    class CityNode
    {
        public string name;
        public int toll;
        public int routeCost;

        public CityNode(string inName, int inToll)
        {
            name = inName;
            toll = inToll;
        }
    }
}
