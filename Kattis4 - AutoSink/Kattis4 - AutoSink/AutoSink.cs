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
            Map map = new Map();
            List<string[]> trips = new List<string[]>();

            int cityCount = -1;
            int hwCount = -1;
            int tripCount = -1;
            int lc = 0;
            string[] lArray;
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
                    lArray = line.Split(' ');
                    map.cities.Add(lArray[0], new City(lArray[0], Int32.Parse(lArray[1])));
                    lc++;
                    continue;
                }
                else if (((cityCount + 1) < lc) && (lc < (cityCount + hwCount + 2)))
                {
                    lArray = line.Split(' ');
                    map.cities[lArray[0]].dests.Add(map.cities[lArray[1]].name, map.cities[lArray[1]]);
                    lc++;
                    continue;
                }
                else if ((cityCount + hwCount + 2) < lc)
                {
                    lArray = line.Split(' ');
                    trips.Add(new string[] { lArray[0], lArray[1] });
                    lc++;
                    continue;
                }
            }

            DFSResult[] results = new DFSResult[tripCount];
            for(int i = 0; i < tripCount; i++)
            {
                Console.Out.WriteLine("\nTRIP " + (i + 1) + ": " + trips[i][0] + " to " + trips[i][1]);
                DFSResult dfsr = DFS(map, trips[i][0], trips[i][1]);

                if (dfsr.hasRoute)
                    Console.Out.WriteLine(dfsr.cost);
                else
                    Console.Out.WriteLine("NO");
            }

            Console.Read();
        }

        static DFSResult DFS(Map map, string start, string finish)
        {
            if (start == finish)
                return new DFSResult(true, 0);

            List<City> reachable = new List<City>();

            map.Reset();
            Explore(map, start);

            foreach (City c in map.cities.Values)
                if (c.visited)
                    reachable.Add(c);

            reachable.Sort();

            if (!reachable.Contains(map.cities[finish]))
                return new DFSResult(false, 0);

            foreach (City c in reachable)
                c.SetCost(start, finish);


            return new DFSResult(true, map.cities[start].cost);
        }

        static void Explore(Map map, string cName)
        {
            map.cities[cName].visited = true;
            map.cities[cName].pre = ++map.vNum;
            foreach (City d in map.cities[cName].dests.Values)
                if (!d.visited)
                    Explore(map, d.name);
            map.cities[cName].post = ++map.vNum;
        }
    }

    class City : IComparable
    {
        public string name;
        public int toll;
        public Dictionary<string, City> dests;
        public bool visited;
        public int pre;
        public int post;
        public int cost;

        public City(string _name, int _toll)
        {
            name = _name;
            toll = _toll;
            dests = new Dictionary<string, City>();
            visited = false;
            pre = 0;
            post = 0;
            cost = 0;
        }

        public void SetCost(string start, string finish)
        {
            List<int> costs = new List<int>();

            foreach (City d in dests.Values)
                costs.Add(d.cost);

            if (name == finish || dests.Count == 0)
                cost = toll;
            else if (name == start)
                if (dests.ContainsKey(finish))
                    cost = dests[finish].cost;
                else
                    cost = costs.Min();
            else
                if (dests.ContainsKey(finish))
                    cost = toll + dests[finish].cost;
                else
                    cost = toll + costs.Min();
        }

        public void Reset()
        {
            cost = 0;
            visited = false;
            pre = 0;
            post = 0;
        }

        public int CompareTo(object obj)
        {
            City other = (City)obj;
            if (this.post < other.post)
                return -1;
            else if (this.post > other.post)
                return 1;
            return 0;
        }
    }

    class Map
    {
        public Dictionary<string, City> cities;
        public int vNum;

        public Map()
        {
            cities = new Dictionary<string, City>();
            vNum = 0;
        }

        public void Reset()
        {
            vNum = 0;
            foreach (KeyValuePair<string, City> c in cities)
                c.Value.Reset();
        }
    }

    class DFSResult
    {
        public bool hasRoute;
        public int cost;

        public DFSResult(bool _hasRoute, int _cost)
        {
            hasRoute = _hasRoute;
            cost = _cost;
        }

        public override string ToString()
        {
            if (hasRoute)
                return "" + cost;
            else
                return "NO";
        }
    }
}
