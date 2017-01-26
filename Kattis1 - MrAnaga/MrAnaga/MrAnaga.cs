using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrAnaga
{
    class MrAnaga
    {
        static void Main(string[] args)
        {
            HashSet<string> accepted = new HashSet<string>();
            HashSet<string> rejected = new HashSet<string>();

            string w;
            int lc = 0;
            char[] wordChars;
            string sortedWord;

            while ((w = Console.ReadLine()) != null)
            {
                if (lc++ == 0)
                    continue;

                wordChars = w.ToCharArray();
                Array.Sort(wordChars);
                sortedWord = new string(wordChars);

                if (rejected.Contains(sortedWord))
                {
                    continue;
                }
                else if (accepted.Contains(sortedWord))
                {
                    accepted.Remove(sortedWord);
                    rejected.Add(sortedWord);
                }
                else
                {
                    accepted.Add(sortedWord);
                }
            }

            Console.Out.Write(accepted.Count);
        }
    }
}