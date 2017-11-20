using System;
using System.Diagnostics;
using System.Numerics;

namespace RedGate.PrimalityTests
{
    class MillerRabinPrimalityTest : IPrimalityTest
    {
        private static readonly int[] AList, QuickAList;
        const ulong QuickTestLimit = 341550071728321;
        
        static MillerRabinPrimalityTest()
        {
            // Apparently this is sufficient for testing all n < 2^64
            AList = new[]
                        {
                            2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
                            31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
                            73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
                            127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
                            179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
                            233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
                            283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
                            353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
                            419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
                            467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
                            547, 557, 563, 569, 571, 577, 587, 593, 599, 601,
                            607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
                            661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739
                        };
            // This is sufficient for numbers < QuickTestLimit
            QuickAList = new[] {2, 3, 5, 7, 11, 13, 17};
        }

        #region IPrimalityTest Members

        /// <summary>
        /// Miller-Rabin primality test
        /// </summary>
        /// <param name="n">Number to test (greater than or equal to 2)</param>
        /// <returns>True if the number is prime, false otherwise</returns>
        public bool IsPrime(ulong n)
        {
            ulong d = n - 1;
            int s = 0;

            if (n == 1)
                return false;
            if (n == 2)
                return true;
            if ((n % 2) == 0)
                return false;

            while (d % 2 == 0)
            {
                d = d/2;
                s++;
            }

            foreach(int a in (n < QuickTestLimit ? QuickAList : AList))
            {
                ulong mod = (ulong)BigInteger.ModPow(a, d, n);
                if (mod != 1)
                {
                    for (int r = 0; r < s; r++)
                    {
                        if (mod == n - 1)
                            break;
                        mod = (ulong)BigInteger.ModPow(mod, 2, n);
                    }

                    if (mod != n - 1)
                        return false;
                }
            }
            return true;
        }

        #endregion
    }
}