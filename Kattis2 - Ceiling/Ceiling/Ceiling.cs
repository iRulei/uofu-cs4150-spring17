using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceiling
{
    class Ceiling
    {
        static void Main(string[] args)
        {
            //List<Ctree> trees = new List<Ctree>();
            //string ct;
            //int n, k;

            //ct = Console.ReadLine();
            //n = ct[0];
            //k = ct[2];

            //while ((ct = Console.ReadLine()) != null)
            //{
            //    trees.Add(new Ceiling.Ctree(k, ct));
            //}

            Ctree ct = new Ctree("1 2 3 4 5 6 7 8 9");
            Console.Out.WriteLine(ct.ToString());
            Console.Read();
        }

        class Ctree
        {
            private char[] tArray;
            public bool[] tShape;
            private int leafCount;

            public Ctree(string leaves)
            {
                leafCount = (leaves.Length + 1) / 2;

                tArray = new char[(int)Math.Pow(2, leafCount) + 1];
                tShape = new bool[(int)Math.Pow(2, leafCount) + 1];

                tArray[1] = leaves[0];
                tShape[1] = true;

                for (int l = 2; l < leaves.Length; l += 2)
                {
                    int i = 1;

                    while (true)
                    {
                        if (leaves[l] < tArray[i])
                        {
                            if (tShape[2 * i])
                            {
                                i = 2 * i;
                            }
                            else
                            {
                                tArray[2 * i] = leaves[l];
                                tShape[2 * i] = true;
                                break;
                            }
                        }
                        else if (leaves[l] > tArray[i])
                        {
                            if (tShape[2 * i + 1])
                            {
                                i = 2 * i + 1;
                            }
                            else
                            {
                                tArray[2 * i + 1] = leaves[l];
                                tShape[2 * i + 1] = true;
                                break;
                            }
                        }
                    }
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                for(int i = 0; i < (int)Math.Pow(2, leafCount) + 1; i++)
                {
                    if (tShape[i])
                    {
                        sb.Append(tArray[i]);
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                    sb.Append("|");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]\n ");
                for(int i = 0; i < (int)Math.Pow(2, leafCount) + 1; i++)
                {
                    sb.Append(i + " ");
                }
                return sb.ToString();
            }

        }
    }
}