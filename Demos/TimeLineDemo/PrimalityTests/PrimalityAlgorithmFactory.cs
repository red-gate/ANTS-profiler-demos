using System.Collections.Generic;

namespace RedGate.PrimalityTests
{
    static class PrimalityAlgorithmFactory
    {
        private static readonly Dictionary<PrimalityAlgorithm, IPrimalityTest> Store;

        static PrimalityAlgorithmFactory()
        {
            Store = new Dictionary<PrimalityAlgorithm, IPrimalityTest>();
            Store[PrimalityAlgorithm.BruteForce] = new BruteForcePrimalityTest();
            Store[PrimalityAlgorithm.MillerRabin] = new MillerRabinPrimalityTest();
        }

        public static IPrimalityTest CreateBruteForceAlgorithm(ulong startAt)
        {
            BruteForcePrimalityTest bf = new BruteForcePrimalityTest();
            bf.StartAt = startAt;
            return bf;
        }

        internal static IPrimalityTest CreateMillerRabinAlgorithm()
        {
            return Store[PrimalityAlgorithm.MillerRabin];
        }
    }
}