using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceiling
{
    class Ceiling
    {
        static void Main(string[] args)
        {

            List<Ctree> trees = new List<Ctree>();
            HashSet<Ctree> shadows = new HashSet<Ctree>();

            //string line = Console.ReadLine();
            //string[] first = line.Split(' ');
            //int k = Int32.Parse(first[1]);

            //while ((line = Console.ReadLine()) != null)
            //{
            //    trees.Add(new Ceiling.Ctree(k, line));
            //}

            string[] lines = File.ReadAllLines("04_100-10.txt");
            string[] first = lines[0].Split(' ');
            int k = Int32.Parse(first[1]);

            for (int i = 1; i < lines.Length; i++)
            {
                trees.Add(new Ctree(k, lines[i]));
            }

            foreach (Ctree ct in trees)
            {
                shadows.Add(ct);
            }

            Console.Out.WriteLine(shadows.Count);
            Console.Read();
        }

        class Ctree
        {
            private int[] tree;
            public bool[] shadow;
            private int hash = 0;
            private int leafCount;
            private int treeSize;

            public Ctree(int inLC, string leafString)
            {
                leafCount = inLC;
                treeSize = (int)Math.Pow(2, leafCount) + 1;
                int[] leaves = GetLeaves(leafCount, leafString);

                tree = new int[treeSize];
                shadow = new bool[treeSize];

                tree[1] = leaves[0];
                shadow[1] = true;

                for (int l = 1; l < leafCount; l ++)
                {
                    int i = 1;

                    while (true)
                    {
                        if (leaves[l] < tree[i])
                        {
                            if (shadow[2 * i])
                            {
                                i = 2 * i;
                            }
                            else
                            {
                                tree[2 * i] = leaves[l];
                                shadow[2 * i] = true;
                                hash += (int)Math.Pow(10, 2 * i);
                                break;
                            }
                        }
                        else if (leaves[l] > tree[i])
                        {
                            if (shadow[2 * i + 1])
                            {
                                i = 2 * i + 1;
                            }
                            else
                            {
                                tree[2 * i + 1] = leaves[l];
                                shadow[2 * i + 1] = true;
                                hash += (int)Math.Pow(10, 2 * i + 1);
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            public string PrintShadow()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                for (int i = 0; i < (int)Math.Pow(2, leafCount) + 1; i++)
                {
                    if (shadow[i])
                    {
                        sb.Append("x");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                    sb.Append("|");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]\n ");
                for (int i = 0; i < (int)Math.Pow(2, leafCount) + 1; i++)
                {
                    sb.Append(i + " ");
                }
                return sb.ToString();
            }

            private int[] GetLeaves(int leafCount, string leafString)
            {
                int[] leafArray = new int[leafCount];
                string[] nums = leafString.Split();

                for (int i = 0; i < leafCount; i++)
                {
                    leafArray[i] = Int32.Parse(nums[i]);
                }

                return leafArray;
            }

            public override bool Equals(object obj)
            {
                Ctree other = (Ctree)obj;
                return shadow.SequenceEqual(other.shadow);
            }

            public override int GetHashCode()
            {
                return hash;
            }
        }
    }
}