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
                    map.cities[lArray[0]].dests.Add(map.cities[lArray[1]]);
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

            List<City> topSort = DFS(map);



            Console.Read();
        }

        static List<City> DFS(Map map)
        {

            foreach (City c in map.cities.Values)
                c.Reset();

            foreach (City c in map.cities.Values)
                if (!c.visited)
                    Explore(map, c.name);
        }

        static void Explore(Map map, string cName)
        {
            map.cities[cName].visited = true;
            map.cities[cName].pre = ++map.vNum;
            foreach (City d in map.cities[cName].dests)
                if (!d.visited)
                    Explore(map, d.name);
            map.cities[cName].post = ++map.vNum;
        }
    }

    class City
    {
        public string name;
        public int toll;
        public List<City> dests;
        public bool visited;
        public int pre;
        public int post;

        public City(string _name, int _toll)
        {
            name = _name;
            toll = _toll;
            dests = new List<City>();
            visited = false;
            pre = 0;
            post = 0;
        }

        public void Reset()
        {
            toll = 0;
            visited = false;
            pre = 0;
            post = 0;
        }

        public static bool operator <(City c1, City c2)
        {
            if (c1.post < c2.post)
                return true;
            else
                return false;
        }

        public static bool operator >(City c1, City c2)
        {
            if (c1.post > c2.post)
                return true;
            else
                return false;
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
    }
}
