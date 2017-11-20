using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedGate.Demo;

namespace RedGate.PrimalityTests
{
    class PrecomputedTablePrimalityTest : IPrimalityTest
    {
        private readonly IPrimalityTest m_fallbackAlgorithm;
        private readonly PrimeTable m_primeTable;

        /// <summary>
        /// Create a primality test using the supplied table of primes and the designated fallback algorithm
        /// </summary>
        /// <param name="algorithm">The fallback algorithm to use</param>
        /// <param name="table">A table of primes</param>
        public PrecomputedTablePrimalityTest(IPrimalityTest algorithm, PrimeTable table)
        {
            m_fallbackAlgorithm = algorithm;
            m_primeTable = table;
        }

        #region IPrimalityTest Members

        public bool IsPrime(ulong n)
        {
            if (n == 1)
            {
                // Not considered prime
                return false;
            }

            if (m_primeTable.IsInPrimeTable(n))
            {
                // Known prime
                return true;
            }

            ulong limit = (ulong) Math.Sqrt(n);

            // Resharper offers to turn this into LINQ, but according to APP, it's way slower!
            foreach(ulong p in m_primeTable)
            {
                // Only try primes lower than sqrt(n).
                if(p > limit)
                    break;
                if (n % p == 0)
                {
                    // Composite (p is a factor of n)
                    return false;
                }
            }

            // Don't know - use backup method
            return m_fallbackAlgorithm.IsPrime(n);
        }

        #endregion
    }
}
