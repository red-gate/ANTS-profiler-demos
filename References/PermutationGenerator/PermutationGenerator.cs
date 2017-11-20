using System.Collections.Generic;
using System.Text;

namespace RedGate.Demo
{
    /// <summary>
    /// http://en.wikipedia.org/wiki/Steinhaus%E2%80%93Johnson%E2%80%93Trotter_algorithm
    /// </summary>
    public sealed class PermutationGenerator
    {
        /*
         * This is not intended to be the most efficient implementation of the SJT algorithm, it's
         * just a convenient (and interesting) data source for the report generation example.
         * 
         * You could use ANTS Performance Profiler to see where the bottlenecks in this implementation live..
        */
        private enum MobilityDirection
        {
            Left,
            Right
        } ;

        /// <summary>
        /// Represents an item in the permutation
        /// </summary>
        private sealed class ListEntry
        {
            internal readonly int Value;
            internal MobilityDirection Mobility;

            internal ListEntry(int val, MobilityDirection dir)
            {
                Value = val;
                Mobility = dir;
            }
        }

        private readonly char[] m_data;
        private readonly List<ListEntry> m_indices;

        /// <summary>
        /// Returns a permutation generator for the given string
        /// </summary>
        /// <param name="s">The string to generate permutations for</param>
        public PermutationGenerator(string s)
        {
            m_data = s.ToCharArray();
            m_indices = new List<ListEntry>();
            // The numbers 1..N where N is the number of letters in 's'
            // NET 3.5 => var digits = Enumerable.Range(1, m_data.Length).ToList();

            for (int i = 1; i <= m_data.Length; i++)
                m_indices.Add(new ListEntry(i, MobilityDirection.Left));

            // NET 3.5 => m_indices = digits.ConvertAll(x => new ListEntry(x, MobilityDirection.Left)).ToList();
        }

        /// <summary>
        /// The permutations of the string passed to the constructor
        /// </summary>
        public IEnumerable<string> Permutations
        {
            get
            {
                while (true)
                {
                    // Map the current permutation back into a string
                    // NET 3.5 => yield return new string(m_indices.Select(x => m_data[x.Value-1]).ToArray());

                    StringBuilder sb = new StringBuilder();

                    foreach(ListEntry listEntry in m_indices)
                        sb.Append(m_data[listEntry.Value - 1]);

                    yield return sb.ToString();

                    int largestMobile = -1;
                    int indexLargestMobile = -1;

                    for (int i = 0; i < m_indices.Count; i++)
                    {
                        // i = 0 can't be the largest mobile integer if its mobility is to the left
                        if (i == 0 && m_indices[i].Mobility == MobilityDirection.Left)
                            continue;

                        // i = N can't be the largest mobile integer if its mobility is to the right
                        if (i == m_indices.Count - 1 && m_indices[i].Mobility == MobilityDirection.Right)
                            continue;

                        // Find the largest mobile integer (mobile => number in the mobility direction is less than current number)
                        if ((m_indices[i].Mobility == MobilityDirection.Left && m_indices[i - 1].Value < m_indices[i].Value) ||
                            (m_indices[i].Mobility == MobilityDirection.Right && m_indices[i + 1].Value < m_indices[i].Value))
                        {
                            // m_indices[i] is mobile, but is it the largest?
                            if (largestMobile < m_indices[i].Value)
                            {
                                largestMobile = m_indices[i].Value;
                                indexLargestMobile = i;
                            }
                        }
                    }

                    // No mobile integers are left, so there are no more permutations
                    if (largestMobile == -1)
                        yield break;

                    // tmp variable for swapping
                    ListEntry tmp = m_indices[indexLargestMobile];

                    // Swap either to the left or the right
                    if (m_indices[indexLargestMobile].Mobility == MobilityDirection.Right)
                    {
                        m_indices[indexLargestMobile] = m_indices[indexLargestMobile + 1];
                        m_indices[indexLargestMobile + 1] = tmp;
                    }
                    else
                    {
                        m_indices[indexLargestMobile] = m_indices[indexLargestMobile - 1];
                        m_indices[indexLargestMobile - 1] = tmp;
                    }

                    // NET 3.5 => foreach (ListEntry t in m_indices.Where(t => t.Value > largestMobile))

                    foreach (ListEntry t in m_indices.FindAll(t => t.Value > largestMobile))
                    {
                        t.Mobility = (t.Mobility == MobilityDirection.Left ? MobilityDirection.Right : MobilityDirection.Left);
                    }
                }
            }
        }
    }
}
