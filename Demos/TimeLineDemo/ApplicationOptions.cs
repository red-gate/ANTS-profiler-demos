using System;
using System.ComponentModel;
using RedGate.PrimalityTests;

namespace RedGate.Demo
{
    class ApplicationOptions
    {
        [Category("Prime number lookup table")]
        [ReadOnly(true)]
        public ulong MaxPrime { get; set; }
        [Category("Settings")]
        [Description("How many numbers to generate in each run")]
        public int SampleSize { get; set; }
        [Category("Settings")]
        [Description("The largest random number to generate")]
        public ulong MaxRandom { get; set; }
        [Category("Settings")]
        [Description("Algorithm for prime testing")]
        [ReadOnly(true)]
        public PrimalityAlgorithm Algorithm { get; set; }

        public ApplicationOptions Copy()
        {
            return (ApplicationOptions)MemberwiseClone();
        }

        internal void CopyFrom(ApplicationOptions source)
        {
            Algorithm = source.Algorithm;
            MaxPrime = source.MaxPrime;
            MaxRandom = source.MaxRandom;
            SampleSize = source.SampleSize;
        }
    }
}