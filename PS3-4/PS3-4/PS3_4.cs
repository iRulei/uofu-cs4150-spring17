using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3_4
{
    class PS3_4
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 2, 5, 7, 22 };
            int[] B = new int[] { 7, 8, 9, 14 };

            Console.Out.WriteLine(select(A, B, 5));
            Console.Read();
        }

        public static int select(int[] A, int[] B, int k)
        {
            return select(A, 0, A.Length - 1, B, 0, B.Length - 1, k);
        }

        public static int select(int[] A, int loA, int hiA, int[] B, int loB, int hiB, int k)
        {
            if (hiA < loA)
                return B[k - loA];
            if (hiB < loB)
                return A[k - loB];

            int i = (loA + hiA) / 2;
            int j = (loB + hiB) / 2;

            if (k <= i + j)
                if (A[i] < B[j])
                    return select(A, loA, hiA, B, loB, j-1, k);
                else
                    return select(A, loA, i-1, B, loB, hiB, k);
            else
                if (A[i] < B[j])
                    return select(A, loA, hiA, B, j+1, hiB, k);
                else
                    return select(A, i+1, hiA, B, loB, hiB, k);
        }
    }
}
