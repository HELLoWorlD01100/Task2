using System;
using System.IO;
using System.Linq;

namespace Task_2
{
    public static class Program
    {
        private static readonly string _filePathIn = "in.txt";
        private static readonly string _filePathOut = "out.txt";

        public static void Main()
        {
            var nodes = FileReader.ReadGraph(_filePathIn).ToArray();

            if (nodes.Length == 0)
                throw new ArgumentException();

            if (File.Exists(_filePathOut))
                FileExtensions.ClearFile(_filePathOut);

            var result = new Algorithm().IsBipartiteGraph(nodes[0]);
            FileWriter.WriteAlgorithmResult(_filePathOut, result);
            if (result)
            {
                var colorMinId = nodes.First().Color;
                var invertedColor = colorMinId.InvertColor();
                var firstShareIds = nodes.Where(x => x.Color == colorMinId).Select(x => x.Id).OrderBy(x => x);
                var secondShareIds = nodes.Where(x => x.Color == invertedColor).Select(x => x.Id).OrderBy(x => x);
                FileWriter.Write(_filePathOut, string.Join(" ", firstShareIds.Append(0)));
                FileWriter.Write(_filePathOut, string.Join(" ", secondShareIds));
            }
        }
    }
}