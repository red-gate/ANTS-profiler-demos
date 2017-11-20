using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RedGate.Demo
{
    /// <summary>
    /// Class representing a table of prime numbers. PrimeTable is enumerable.
    /// </summary>
    internal sealed class PrimeTable : IEnumerable<ulong>
    {
        private readonly List<ulong> m_primes;
        public ulong MaxPrimeKnown { get; private set; }

        public PrimeTable()
        {
            m_primes = new List<ulong>();
        }

        /// <summary>
        /// Creates a table of prime numbers up to <paramref name="maxPrime"/>
        /// </summary>
        /// <param name="maxPrime">Maximum number to iterate to (need not be prime)</param>
        /// <param name="ct">Used for cancelling the task</param>
        public void CreatePrimes(int maxPrime, CancellationToken ct)
        {
            if(m_primes.Count > 0)
                throw new InvalidOperationException("CreatePrimes has already been called for this instance");

            Thread.CurrentThread.Name = "PrimeGeneration";
            IEnumerable<int> candidates = Enumerable.Range(2, maxPrime - 2).ToArray();
            int i = 0;

            // This is an implementation of the Euler Sieve
            while (i < candidates.Count())
            {
                // The current element is always a prime
                int multiplier = ((int[])candidates)[i];
                ulong ulMultiplier = (ulong) multiplier;
                // Map { n,n+1,n+2 ... } to { n*n,n(n+1),n(n+2) ... }
                // These are all multiples of n, and therefore non-prime, and can be removed from the list
                var toBeRemoved = candidates.Where(x => x >= multiplier && x <= maxPrime / multiplier).Select(x => x * multiplier);
                candidates = candidates.Except(toBeRemoved);
                // Remember the prime that  has just been seen
                m_primes.Add(ulMultiplier);
                MaxPrimeKnown = ulMultiplier;
                // Check for cancellation via the Task API
                if (ct.IsCancellationRequested)
                {
                    // Acknowledge the cancellation request
                    throw new OperationCanceledException(ct);
                }
                i++;
                // Force the LINQ expressions to be evaluated
                candidates = candidates.ToArray();
            }
        }

        public bool IsInPrimeTable(ulong n)
        {
            return n <= MaxPrimeKnown && m_primes.BinarySearch(n, null) >= 0;
        }

        #region IEnumerable<ulong> Members

        public IEnumerator<ulong> GetEnumerator()
        {
            return m_primes.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_primes.GetEnumerator();
        }

        #endregion
    }
}