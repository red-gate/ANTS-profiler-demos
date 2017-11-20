using System;
using System.IO;
using System.Text;

namespace RedGate.Demo
{
    /// <summary>
    /// This is version 2 of the permutation printer
    /// </summary>
    class Program
    {
        /// <summary>
        /// Generates a report from the permutation object and writes it to the console in 50,000 character blocks.
        /// In a more realistic scenario, the write would be to a file, in which case blocking would improve efficiency -
        /// here it doesn't serve any real purpose.
        /// </summary>
        /// <param name="p">Permutation object</param>
        static void GenerateReport(PermutationGenerator p)
        {
            // Use a StringBuilder instead of string concatentation
            StringBuilder sb = new StringBuilder();

            foreach (var permutation in p.Permutations)
            {
                sb.AppendLine(permutation);

                if (sb.Length > 500000)
                {
                    Console.WriteLine(sb.ToString());
                    sb.Length = 0; // Make buffer ready for re-use [note: NET4 has sb.Clear()]
                }
            }
            Console.WriteLine(sb.ToString());
        }

        /*
         * This program prints all permutations of the first commandline argument, or "HelloTest" if no argument is supplied.
         * HelloTest has 362880 permutations, which provide enough computation to demonstrate the profiler. 
         */
        static void Main(string[] args)
        {
            PermutationGenerator permutationGenerator = args.Length == 0
                                                ? new PermutationGenerator("HelloTest")
                                                : new PermutationGenerator(args[0]);

            // The performance profiler supports user defined events to help you identify areas of program execution.
            // These appear as vertical bars on the timeline, and the mouseover tooltip will display the name.
            RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent("Begin report");
            GenerateReport(permutationGenerator);
            RedGate.Profiler.UserEvents.ProfilerEvent.SignalEvent("End report");
            Console.ReadLine();
        }
    }
}
