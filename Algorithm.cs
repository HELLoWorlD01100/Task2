using System.Collections.Generic;

namespace Task_2
{
    public class Algorithm
    {
        private readonly Queue<Node> _queue = new Queue<Node>();
        public bool IsBipartiteGraph(Node startNode)
        {
            return Bfs(startNode);
        }

        private bool Bfs(Node startNode)
        {
            startNode.Color = Color.Black;
            _queue.Enqueue(startNode);
            while (_queue.Count != 0)
            {
                var node = _queue.Dequeue();
                foreach (var adjacentNode in node.AdjacentNodes)
                {
                    if (adjacentNode.Color == Color.None)
                    {
                        adjacentNode.Color = node.Color.InvertColor();
                        _queue.Enqueue(adjacentNode);
                    }
                    else if (adjacentNode.Color == node.Color)
                        return false;
                }
            }

            return true;
        }
    }
}