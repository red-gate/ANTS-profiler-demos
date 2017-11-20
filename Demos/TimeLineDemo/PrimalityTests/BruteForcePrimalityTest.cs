using System;

namespace RedGate.PrimalityTests
{
    class BruteForcePrimalityTest : IPrimalityTest
    {
        /// <summary>
        /// Prime number to start searching from
        /// </summary>
        public ulong StartAt { get; set; }

        public BruteForcePrimalityTest()
        {
            StartAt = 3;
        }

        #region IPrimalityTest Members

        /// <summary>
        /// Implementation using a brute force search of the factors from StartAt to sqrt(n)
        /// </summary>
        /// <param name="n">The number to test</param>
        /// <returns>True if the number is prime, false otherwise</returns>
        public bool IsPrime(ulong n)
        {
            if (n == 2 || n == 3)
                return true;
            // Even numbers as special case
            if (n % 2 == 0)
                return false;

            // Gain small amount of efficency by incrementing by 2 each time
            for (ulong i = StartAt; i * i <= n; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        #endregion
    }
}