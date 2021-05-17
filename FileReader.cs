using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_2
{
    public static class FileReader
    {
        public static string[] Read(string filePath)
        {
            var text = File.ReadAllLines(filePath);
            return text;
        }

        public static IEnumerable<Node> ReadGraph(string filePath)
        {
            var text = Read(filePath).Skip(1).ToArray();
            return ParseAdjacentMatrix(text);
        }

        private static IEnumerable<Node> ParseAdjacentMatrix(string[] lines)
        {
            var adjacentInfo = lines.Select(x => x.Split(' ')).ToArray();
            var nodes = Enumerable.Range(1, adjacentInfo.Length).Select(x => new Node(x)).ToArray();
            for (var i = 0; i < nodes.Length; i++)
            {
                var currentNode = nodes[i];
                var adjacentNodesInfo = adjacentInfo[i];
                for (var j = 0; j < adjacentNodesInfo.Length; j++)
                {
                    var adjacentNodeInfo = adjacentNodesInfo[j];
                    if (int.TryParse(adjacentNodeInfo, out var isAdjacent) && isAdjacent == 1)
                    {
                        currentNode.AdjacentNodes.Add(nodes[j]);
                    }
                }
            }

            return nodes;
        }
    }
}