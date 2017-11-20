using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedGate.PrimalityTests
{
    internal enum PrimalityAlgorithm
    {
        BruteForce,
        MillerRabin
    }

    interface IPrimalityTest
    {
        bool IsPrime(ulong n);
    }
}
