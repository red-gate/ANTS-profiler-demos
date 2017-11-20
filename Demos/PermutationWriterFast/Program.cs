using System;
using System.IO;
using System.Text;

namespace RedGate.Demo
{
    /// <summary>
    /// This is version 2 of the file-writing permutation printer
    /// </summary>
    class Program
    {
        /// <summary>
        /// Generates a report from the permutation object and writes it to a file.
        /// </summary>
        /// <param name="p">Permutation object</param>
        static void GenerateReport(PermutationGenerator p)
        {
            string tempFile = Path.GetTempFileName();
            Console.WriteLine("Writing to {0}", tempFile);

            using (StreamWriter sw = new StreamWriter(tempFile))
            {
                foreach (var permutation in p.Permutations)
                {
                    sw.WriteLine(permutation);
                }
            }

            File.Delete(tempFile);
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
            Console.WriteLine("Finished");
            // Console.ReadLine();
        }
    }
}

