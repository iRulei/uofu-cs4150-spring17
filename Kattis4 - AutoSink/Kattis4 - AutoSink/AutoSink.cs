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
                if (lc == 0)
                {
                    cityCount = Int32.Parse(line);
                }
                else if (lc == (cityCount + 1))
                {
                    hwCount = Int32.Parse(line);
                }
                else if (lc == (cityCount + hwCount + 2))
                {
                    tripCount = Int32.Parse(line);
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
