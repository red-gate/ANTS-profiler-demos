using System.IO;

namespace RedGate.Demo
{
    /// <summary>
    /// A poorly performing logging API
    /// </summary>
    static class LogApi
    {
        /// <summary>
        /// Log <paramref name="s"/> to <paramref name="filename"/>, appending a newline
        /// </summary>
        /// <param name="filename">The file to write to</param>
        /// <param name="s">The string to log</param>
        public static void LogToFile(string filename, string s)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(s);
            }
        }
    }
}