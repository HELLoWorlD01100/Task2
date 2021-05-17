using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_2
{
    public static class FileWriter
    {
        public static void Write(string filePath, string content)
        {
            File.AppendAllText(filePath, content + Environment.NewLine);
        }

        public static void WriteAlgorithmResult(string filePath, bool result)
        {
            var content = result ? "Y" : "N";
            Write(filePath, content);
        }

        public static void Write<T>(string filePath, IEnumerable<T> nodes)
        {
            File.AppendAllLines(filePath, nodes.Select(x => x.ToString()));
        }
    }
}